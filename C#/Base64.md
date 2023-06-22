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

  return Ok(new {fichier = base64, nomFichier = nomFicher});
```

## En Vue Js 3

```js
// Décoder le base64
  const byteCharacters = atob(response.data.fichier);

  const byteNumbers = new Array(byteCharacters.length);

  for (let i = 0; i < byteCharacters.length; i++) {
      byteNumbers[i] = byteCharacters.charCodeAt(i);
  }

  const byteArray = new Uint8Array(byteNumbers);

  var fileURL = window.URL.createObjectURL(new Blob([byteArray]));
  var fileLink = document.createElement('a');
  fileLink.href = fileURL;
  fileLink.setAttribute('download', response.data.nomFichier + '.txt');
  document.body.appendChild(fileLink);
  fileLink.click();
```
