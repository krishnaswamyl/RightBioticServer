using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Windows.Forms;


namespace xbitsServer
{
    public partial class PatientDetails : Form
    {
        private String fileName = String.Empty;
        public PatientDetails()
        {
            InitializeComponent();
            
        }

        private void PatientDetails_Load(object sender, EventArgs e)
        {
           
            foreach (Control ct in panel1.Controls)
            {
                ct.Enabled = false;
            }
            dateTimePicker1.Format = DateTimePickerFormat.Short;
            dateTimePicker1.Value = DateTime.Today;
            DateTime today = DateTime.Now;
            DateTime sevenDaysEarlier = today.AddDays(-7);            
            dateTimePicker1.MaxDate = today;  
            dateTimePicker1.MinDate = sevenDaysEarlier;

            textBoxTop.Text = Properties.Settings.Default.Top.ToString();
            textBoxLeft.Text = Properties.Settings.Default.Left.ToString();
            textBoxRight.Text = Properties.Settings.Default.Right.ToString();
            textBoxBott.Text = Properties.Settings.Default.Bottom.ToString();
            textBoxPassword.Text = Properties.Settings.Default.PassWord;
            textBoxUserName.Text = Properties.Settings.Default.UserName;
            comboBoxSex.SelectedIndex = 0;
        }

        private void buttonSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = "All Files (*.txt)|*.txt";
            choofdlog.FilterIndex = 1;
            //choofdlog.InitialDirectory = Properties.Settings.Default.Path.ToString() + "RightBiotic\\";
            DialogResult dr = choofdlog.ShowDialog();
            if(dr == DialogResult.Cancel)
            {
                return;
            }
            fileName = choofdlog.FileName;

            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();
            fileStream.Close();
            char[] charsToTrimPid = { ':' };
            String[] temp = lines[0].Split(charsToTrimPid);
            textBoxPid.Text = temp[1];

            foreach (Control ct in panel1.Controls)
            {
                if (ct.Name == "textBoxPid") continue;
                ct.Enabled = true;
            }
            
            foreach(String s in lines)
            {
                richTextBox1.AppendText(s+"\n");
            }

            

        }

        private void buttonExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonMargin_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Top = int.Parse(textBoxTop.Text.ToString());
            Properties.Settings.Default.Left = int.Parse(textBoxLeft.Text.ToString());
            Properties.Settings.Default.Right = int.Parse(textBoxRight.Text.ToString());
            Properties.Settings.Default.Bottom = int.Parse(textBoxBott.Text.ToString());
            Properties.Settings.Default.Save();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            String pid = textBoxPid.Text;
            if (pid.Length < 1)
            {
                MessageBox.Show("Patient ID is less than 5 characters\n Please select a vaild File");
                return;
            }
            String F_name = String.Empty;
            char[] trim = { '.' };
            char[] trimspace = { ' ' };
            int Top, Left, Right, Bottom = 50;
            Top = Properties.Settings.Default.Top;
            Left = Properties.Settings.Default.Left;
            Right = Properties.Settings.Default.Right;
            Bottom = Properties.Settings.Default.Bottom;

            string[] lines;
            var list = new List<string>();
            var fileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
            {
                string line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    list.Add(line);
                }
            }
            lines = list.ToArray();
            fileStream.Close();
            DateTime dt = dateTimePicker1.Value;

            Document document = new Document(PageSize.A4, Left, Right, Top, Bottom);
            F_name = fileName.TrimEnd(trim) + ".pdf";
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(F_name, FileMode.Create));
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message.ToString());
                return;
            }

            document.Open();
            PdfPTable table = new PdfPTable(4);
            table.TotalWidth = 470f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            //relative col widths in proportions - 1/3 and 2/3
            float[] widths = new float[] { 2f, 5f, 2f, 1.5f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fontRed = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.RED);
            iTextSharp.text.Font fontGreen = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD, BaseColor.GREEN);

            

            PdfPCell cell = new PdfPCell(new Phrase("Laboratary Report", font));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            table.AddCell("Patient Name:");
            table.AddCell(textBoxPname.Text); //Patient Name

            cell = new PdfPCell(new Phrase("Sample Date:"));
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            table.AddCell(dt.ToShortDateString());  // Date Received

             table.AddCell("Age/Sex:");
            table.AddCell(textBoxAge.Text + "Y / " + comboBoxSex.SelectedItem.ToString());   // Age and sex
            

            cell = new PdfPCell(new Phrase("Report Date:"));
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            String[] td = lines[1].Split(trimspace);
            table.AddCell(td[0]);

            table.AddCell("Referred by:");
            cell = new PdfPCell(new Phrase("Dr." + textBoxDocName.Text));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            document.Add(table);

            String rs = "CULTURE REPORT";
            Paragraph para = new Paragraph();
            para.Alignment = Element.ALIGN_CENTER;
            para.SpacingBefore = 5;
            para.Font = FontFactory.GetFont(FontFactory.HELVETICA, 16f, 5, BaseColor.BLACK);
            para.Add(rs);
            document.Add(para);

            para = new Paragraph();
            para.Alignment = Element.ALIGN_LEFT;
            para.SpacingBefore = 5;
            para.TabSettings = new TabSettings(90);

            para.Add(new Chunk("Sample"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(": "));
            para.Add(new Chunk("Urine\n"));
            para.Add(new Chunk("Test"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(": "));
            para.Add(new Chunk("AST - (Antibiotic Sensitivity Test)\n"));

            para.Add(new Chunk("Organism Name"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(": "));
            para.Add(new Chunk(lines[2] + "\n"));
           
            para.Add(new Chunk("Volume"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(": "));
            para.Add(new Chunk(lines[3]+ "\n"));
            document.Add(para);

            table = new PdfPTable(7);
            table.TotalWidth = 470f;
            widths = new float[] { 0.6f, 3f, 0.8f, 0.2f, 0.6f, 3f, 0.8f };
            table.SetWidths(widths);
            //fix the absolute width of the table
            table.LockedWidth = true;
            table.SpacingBefore = 5;
            iTextSharp.text.Font f = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.TIMES_ROMAN, 13, 1);
            table.HorizontalAlignment = 0;
            PdfPCell pc = new PdfPCell(new Phrase("S.no", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);
            pc = new PdfPCell(new Phrase("Antibiotic Name", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);

            pc = new PdfPCell(new Phrase("Result", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);

            pc = new PdfPCell(new Phrase(" "));
            pc.HorizontalAlignment = 0;
            pc.Rowspan = 23;
            table.AddCell(pc);

            pc = new PdfPCell(new Phrase("S.no", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);
            pc = new PdfPCell(new Phrase("Antibiotic Name", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);

            pc = new PdfPCell(new Phrase("Result", f));
            pc.HorizontalAlignment = 0;
            table.AddCell(pc);
            font = new iTextSharp.text.Font(bf, 12, iTextSharp.text.Font.NORMAL);
            int count = lines.Length;
            int re = 0;
            int oddeven = 0;
            int len = 0;
            len = (count - 5);
            oddeven = len % 2;
            count = (int)len / 2;
            if (oddeven == 1)
            {
                count += 1;               
            }
            re = count + 1;

            int le = 1;
            string[] antres;
            char[] spl = { ',' };
            for (int m = 0; m < count; m++)
            {
                pc = new PdfPCell(new Phrase(le++.ToString("00"), font));
                pc.HorizontalAlignment = 0;
                table.AddCell(pc);

               
                antres = lines[m + 4].Split(spl);
                pc = new PdfPCell(new Phrase(antres[0], font));

                pc.HorizontalAlignment = 0;
                table.AddCell(pc);
                Phrase tr = null;
                switch (antres[1])
                {
                    case "I":
                        tr = new Phrase(antres[1], font);
                        break;

                    case "R":
                        tr = new Phrase(antres[1], fontRed);
                        break;
                    case "S":
                        tr = new Phrase(antres[1], fontGreen);
                        break;
                }             
                
                pc = new PdfPCell(tr);
                pc.HorizontalAlignment = 1;
                table.AddCell(pc);

                antres = lines[3+re].Split(spl);
                pc = new PdfPCell(new Phrase(re++.ToString("00"), font));
                pc.HorizontalAlignment = 0;
                table.AddCell(pc);

                if (antres.Length == 1)
                {
                    pc = new PdfPCell(new Phrase(" ", font));
                }
                else
                {
                    pc = new PdfPCell(new Phrase(antres[0], font));
                }
                pc.HorizontalAlignment = 0;
                table.AddCell(pc);

                if (antres.Length == 1)
                {
                    tr = new Phrase(" ", font);
                }else
                {
                    
                    switch (antres[1])
                    {
                        case "I":
                            tr = new Phrase(antres[1], font);
                            break;

                        case "R":
                            tr = new Phrase(antres[1], fontRed);
                            break;
                        case "S":
                            tr = new Phrase(antres[1], fontGreen);
                            break;
                    }
                    //tr = new Phrase(antres[1], font);
                }
               
                pc = new PdfPCell(tr);
                pc.HorizontalAlignment = 1;
                table.AddCell(pc);

            }

            document.Add(table);
            para = new Paragraph();
            //para.Alignment = Element.ALIGN_CENTER;
            para.SpacingBefore = 2;


            para.Font = font;
            para.Add(new Chunk("R: RESISTANT"));
            para.Add(Chunk.TABBING);
            para.Add(Chunk.TABBING);
            para.Add(Chunk.TABBING);
            para.Add(new Chunk("S: SENSITIVE"));
            para.Add(Chunk.TABBING);
            para.Add(Chunk.TABBING);
            para.Add(Chunk.TABBING);
            para.Add(new Chunk("I: INTERMEDIATE"));
            document.Add(para);

            PdfPTable res = new PdfPTable(3);
            res.TotalWidth = 470f;
            res.LockedWidth = true;
            //widths = new float[] { 3f, 1f, 3f,};
            //res.SetWidths(widths);
            res.HorizontalAlignment = 0;
            res.SpacingBefore = 15;

            //relative col widths in proportions - 1/3 and 2/3
            float[] wid = new float[] { 2f, 0.5f, 2f };
            res.SetWidths(wid);

            Chunk ck = new Chunk("B");
            ck.Font = FontFactory.GetFont(FontFactory.HELVETICA, 12f, 1, BaseColor.RED);
            para = new Paragraph();
            para.SpacingBefore = 10;
            para.Add(new Chunk("Only for Office Use"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("RIGHT"));
            para.Add(ck);
            para.Add(new Chunk("IOTIC REPORT"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("TECHNICIAN:_________________"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));

            res.AddCell(new PdfPCell(para));
            PdfPCell dd = new PdfPCell();
            dd.Border = 0;
            res.AddCell(dd);


            para = new Paragraph();
            para.SpacingBefore = 10;
            para.Add(new Chunk("DEPARTMENT OF PATHOLOGY"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("Dr. ____________________"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("Sign ___________________"));
            para.Add(new Chunk("\n"));
            para.Add(new Chunk("\n"));
            res.AddCell(new PdfPCell(para));
            document.Add(res);
            document.Dispose();
            //document.NewPage();
            System.Diagnostics.Process.Start(F_name);

        }

        private void buttonEmail_Click(object sender, EventArgs e)
        {
            OpenFileDialog choofdlog = new OpenFileDialog();
            choofdlog.Filter = " PDF Files (*.pdf)|*.pdf| All Files (*.txt)|*.txt";
            choofdlog.FilterIndex = 1;
            DialogResult dr = choofdlog.ShowDialog();
            if (dr == DialogResult.Cancel)
            {
                return;
            }
            fileName = choofdlog.FileName;
            Properties.Settings.Default.UserName = textBoxUserName.Text;
            Properties.Settings.Default.PassWord = textBoxPassword.Text;
            Properties.Settings.Default.Save();
            try
            {
                
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                mail.From = new MailAddress(textBoxUserName.Text);
                mail.To.Add(textBoxToemail.Text);
                mail.Subject = "Micro Biology Report";
                mail.Body = "PLease find attached file which contains the report";

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(fileName);
                mail.Attachments.Add(attachment);

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(textBoxUserName.Text, textBoxPassword.Text);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("Mail Sucessfully Sent");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
