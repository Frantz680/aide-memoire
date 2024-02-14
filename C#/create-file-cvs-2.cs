//Pour remplacer EPplus, j’ai trouvé ClosedXML :

//https://closedxml.io/ClosedXML/

//Tu installes le package avec Nugets : 

//Install-Package ClosedXML
//Et pour le code, c’est trop facile. Mes données sont dans une collection que j’ai appelé « lignes ». Je charge les données à partir de la cellule A2 (2ème ligne, 1ère colonne) :

using (var workbook = new XLWorkbook())
{
var worksheet = workbook.Worksheets.Add("Feuille 1");
worksheet.Row(1).Style.Font.Bold = true;
worksheet.Cell("A1").Value = "Alias";
worksheet.Cell("B1").Value = "Dossier";
worksheet.Cell("C1").Value = "Matricule";
worksheet.Cell("D1").Value = "Année/Mois";
worksheet.Cell("E1").Value = "Année";
worksheet.Cell("F1").Value = "Mois";
worksheet.Cell("G1").Value = "Nb d'Extras";
worksheet.Cell("A2").InsertData(lignes);
workbook.SaveAs(fullXLSXFileName);
}
