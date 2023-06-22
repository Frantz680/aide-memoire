## En C#


```c#
  byte[] bytes;
  await _spviContext.SaveChangesAsync();

  var memory = new MemoryStream();
  using (var stream = new FileStream(docPath + "/text.txt", FileMode.Open))
  {
      await stream.CopyToAsync(memory);
      bytes = memory.ToArray();
  }
  memory.Position = 0;

  string base64 = Convert.ToBase64String(bytes);
```
