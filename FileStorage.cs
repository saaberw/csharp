 
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
