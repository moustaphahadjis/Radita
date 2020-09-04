using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Data;
using System.Windows.Forms;

namespace Radita.Classes
{
    class printOut
    {
        string path;
        public printOut()
        {
            path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Radita\";
        }
        public void print(DataGridView data, string Client, string Total, string numero)
        {

            Word.Application app = new Word.Application();
            try
            {
                app.Visible = false;

                Word.Document doc = app.Documents.Open(path + @"template.docx");

                //Proforma NUmber
                Database.bill bill = new Database.bill();
                int BillNum = bill.getNum();
                

                app.Selection.Find.Execute(FindText: "BillNum", ReplaceWith: BillNum.ToString() + "/" + DateTime.Now.Year.ToString(), Replace: Word.WdReplace.wdReplaceAll);
                app.Selection.Find.Execute(FindText: "name", ReplaceWith: Client, Replace: Word.WdReplace.wdReplaceAll);
                app.Selection.Find.Execute(FindText: "datevente", ReplaceWith: "Le " + DateTime.Now.Day.ToString() + "/" + DateTime.Now.Month.ToString() + "/" + DateTime.Now.Year.ToString(), Replace: Word.WdReplace.wdReplaceAll);
                app.Selection.Find.Execute(FindText: "NUMERO", ReplaceWith: numero, Replace: Word.WdReplace.wdReplaceAll);


                //foreach (DataGridViewRow row in data.Rows
                for (int i = data.Rows.Count - 1; i >= 0; i--)
                {
                    
                    
                    doc.Tables[1].Rows[2].Cells[1].Range.Text = data.Rows[i].Cells[0].Value.ToString();
                    doc.Tables[1].Rows[2].Cells[2].Range.Text = data.Rows[i].Cells[1].Value.ToString();
                    doc.Tables[1].Rows[2].Cells[3].Range.Text = data.Rows[i].Cells[2].Value.ToString();
                    doc.Tables[1].Rows[2].Cells[4].Range.Text = data.Rows[i].Cells[3].Value.ToString();
                    doc.Tables[1].Rows[2].Cells[5].Range.Text = (Convert.ToDouble(data.Rows[i].Cells[2].Value.ToString()) * Convert.ToDouble(data.Rows[i].Cells[3].Value.ToString())).ToString() + " FCFA";

                    doc.Tables[1].Rows.Add(doc.Tables[1].Rows[2]);
                }

                doc.Tables[1].Rows[2].Delete();
                //doc.Tables[1].Rows[data.Rows.Count + 2].Delete();
                doc.Tables[1].Rows.Last.Cells[2].Range.Text = Total + " FCFA";

                doc.SaveAs2(path + BillNum.ToString() + ".docx");
                //Close in order to save
                doc.Close();
                
               // doc = app.Documents.Open(path + BillNum.ToString() + ".docx");
                bill.save(BillNum.ToString(), path + BillNum.ToString() + ".docx");

                //Open it back
                doc = app.Documents.Open(path + BillNum.ToString() + ".docx");
                app.Visible = true;
            }
            catch(Exception e)
            {
                MessageBox.Show(e.ToString());
                app.Quit();
            }

        }

    }
}
