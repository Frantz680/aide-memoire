//Docs :
// https://github.com/nissl-lab/npoi

//Installation :
//VS → Tools →  Nuget Package Manager → Package Manager Console → Install-Package NPOI -Version 2.6.2

//Exemple :
//Exemple : https://www.c-sharpcorner.com/article/export-and-import-data-using-npoi-library-in-net-core-2-razor-pages/

using NPOI.HSSF.UserModel; // Pour les fichiers XLS
using NPOI.SS.UserModel;
using System.IO;

string nomFichier = "Penibilite_" + codeEntreprise + "_Annee_" + anneeRattachement;
                string fullXLSFileName = _configuration.GetValue<string>("PathDossier:Temp") + nomFichier + ".xls";
                using (FileStream file = new FileStream(fullXLSFileName, FileMode.Create, FileAccess.Write))
                {
                    IWorkbook workbook = new HSSFWorkbook();
                    ISheet worksheet = workbook.CreateSheet("Penibilite");

                    int ligne = 0;
                    foreach (var sal in querySalarieFinal)
                    {
                        IRow row = worksheet.CreateRow(ligne);

                        row.CreateCell(0).SetCellValue(sal.Entmat);

                        if (sal.penibilite.Count() > 0)
                        {
                            var hyperbare = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "05");
                            row.CreateCell(1).SetCellValue(hyperbare != null ? "X" : "");

                            var tempExtreme = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "06");
                            row.CreateCell(2).SetCellValue(tempExtreme != null ? "X" : "");

                            var bruit = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "07");
                            row.CreateCell(3).SetCellValue(bruit != null ? "X" : "");

                            var nuit = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "08");
                            row.CreateCell(4).SetCellValue(nuit != null ? "X" : "");

                            var equipeAlternantes = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "09");
                            row.CreateCell(5).SetCellValue(equipeAlternantes != null ? "X" : "");

                            var travailRep = sal.penibilite.FirstOrDefault(x => x.CodePenibilite == "10");
                            row.CreateCell(6).SetCellValue(travailRep != null ? "X" : "");
                        }

                        ligne++;
                    }

                    workbook.Write(file);
                }

                var path = fullXLSFileName;
                var memory = new MemoryStream();
                using (var stream = new FileStream(path, FileMode.Open))
                {
                    stream.CopyTo(memory);
                }
                memory.Position = 0;
                return File(memory, "application/octet-stream", Path.GetFileName(path));
