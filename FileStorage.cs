 
 /// ## Read file content as byte arrays via stream
 public void ProcessCfgFile(string cfgFilename)
    {
      List<string> fileList = new List<string>();
      try
      {
         ///Auto Proccess BOM(Byte Order mark)
      	using (Stream ms = new MemoryStream(resourceManagerProxy.ReadFile(cfgFilename)))
        using (StreamReader stream = new StreamReader(ms, Encoding.UTF8))
        {
           while (stream.Peek() >= 0)
           {
           string fileName = stream.ReadLine();
           if (string.IsNullOrWhiteSpace(fileName))
              continue;
           fileList.Add(fileName);
           }                        
         }
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
