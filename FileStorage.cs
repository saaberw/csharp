 
//In .NET, a string (System.String) can contain an initial UTF-8 Byte Order Mark (BOM) which might not be seen in ordinary processing but is present when converted to a character array or into an encoding byte array.
//
//For example, a text file might be saved in UTF8 format with UTF-8 Byte Order Mark bytes at the start, ie 0xEF 0xBB 0xBF. You might receive this file in ASP.NET using a FileUpload control, or read it directly in a Forms .NET app in C#:
//
//byte[] FileBytes = File.ReadAllBytes(path);
//string content = Encoding.UTF8.GetString(FileBytes);
//
//
//If the file contains these 7 bytes (in hex) EF BB BF 44 65 61 72 then content will superficially contain the single word "Dear", eg as seen in the debugger, and content.StartsWith("Dear") will return true.

 /// ## Read file content as byte arrays via stream
 public List<string> ReadFileContentToList(string filename)
    {
      List<string> fileList = new List<string>();
      try
      {
         ///Auto Proccess BOM(Byte Order mark)
      	 using (Stream ms = new MemoryStream(resourceManagerProxy.ReadFile(filename)))
        using (StreamReader stream = new StreamReader(ms, Encoding.UTF8))
        {
           while (stream.Peek() >= 0)
           {
           string line = stream.ReadLine();
           //if (string.IsNullOrWhiteSpace(line))
           //   continue;
           fileList.Add(line);
           }                        
         }
       return fileList;
     }
     catch (Exception e)
     {
        MessageBox.Show($"`File: `{cfgFilename}`\n  Message:\n[{e.Message}]");
     }


     //Manual Proccess BOM(Byte Order mark)
     //if (bytes.Length > 2 && bytes[0] == 0xEF && bytes[1] == 0xBB && bytes[2] == 0xBF)
     //{
     //    bytes = bytes.Skip(3).ToArray();
     //}
     //string cfgContent = Encoding.UTF8.GetString(bytes);                    
     //Files = cfgContent.Split(new string[] { "\r\n", "\r", "\n" }, StringSplitOptions.RemoveEmptyEntries);

}
