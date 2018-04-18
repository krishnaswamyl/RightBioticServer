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
            if(pid.Length < 5)
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
            F_name = fileName.TrimEnd(trim)+".pdf";
            try
            {
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(F_name, FileMode.Create));
            }catch(Exception exp)
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
            float[] widths = new float[] { 1f, 2f, 2f, 1f };
            table.SetWidths(widths);
            table.HorizontalAlignment = 0;
            BaseFont bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
            iTextSharp.text.Font font = new iTextSharp.text.Font(bf, 16, iTextSharp.text.Font.BOLD);

            PdfPCell cell = new PdfPCell(new Phrase("Laboratary Report",font));
            cell.Colspan = 4;
            cell.HorizontalAlignment = 1; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            table.AddCell("Name:");
            table.AddCell(textBoxPname.Text); //Patient Name

            cell = new PdfPCell(new Phrase("Sample Received Date:"));
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);

            table.AddCell(dt.ToShortDateString());  // Date Received
            table.AddCell("Age/Sex:");
            table.AddCell(textBoxAge.Text+"Y/"+comboBoxSex.SelectedItem.ToString());   // Age and sex

            cell = new PdfPCell(new Phrase("Reported Date:"));
            cell.HorizontalAlignment = 2; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            String[] td = lines[1].Split(trimspace);
            table.AddCell(td[0]);

            table.AddCell("Ref. By:");
            cell = new PdfPCell(new Phrase("Dr."+textBoxDocName.Text));
            cell.Colspan = 3;
            cell.HorizontalAlignment = 0; //0=Left, 1=Centre, 2=Right
            table.AddCell(cell);
            document.Add(table);

            String rs = "MICROBIOLOGY REPORT";
            Paragraph para = new Paragraph();
            para.Alignment = Element.ALIGN_CENTER;
            para.SpacingBefore = 15;
            para.Font = FontFactory.GetFont(FontFactory.HELVETICA, 16f, 5, BaseColor.BLACK);
            para.Add(rs);
            document.Add(para);

            para = new Paragraph();
            para.Alignment = Element.ALIGN_LEFT;
            para.SpacingBefore = 15;
            para.TabSettings = new TabSettings(90);
            
            para.Add(new Chunk("Sample"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(":"));
            para.Add(new Chunk("Urine\n"));
            para.Add(new Chunk("Test"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(":"));
            para.Add(new Chunk("Culture and Sensitivity\n"));
            para.Add(new Chunk("Culture Method"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(":"));
            para.Add(new Chunk("Rapid AST Assay\n"));

            para.Add(new Chunk("Bacteria Name"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(":"));
            para.Add(new Chunk(lines[4]+"\n"));

            para.Add(new Chunk("Bacterial Load"));
            para.Add(Chunk.TABBING);
            para.Add(new Chunk(":"));
            para.Add(new Chunk(lines[3] + "\n"));

            document.Add(para);
            
            table = new PdfPTable(2);
            table.TotalWidth = 470f;
            //fix the absolute width of the table
            table.LockedWidth = true;
            table.SpacingBefore = 20;
           
            table.HorizontalAlignment = 0;
            PdfPCell pc = new PdfPCell(new Phrase("Antibiotic Name"));
            pc.HorizontalAlignment = 1;
            table.AddCell(pc);
            pc = new PdfPCell(new Phrase("Result"));
            pc.HorizontalAlignment = 1;
            table.AddCell(pc);
            char[] sp = { ' ' };
            for (int i=5; i<lines.Length;i++)
            {
                String [] kt = lines[i].Split(sp);
                for(int mn=0; mn < kt.Length; mn++)
                {
                    if (kt.Length > 1)
                    {
                        if (kt[mn].Length > 1) {
                            table.AddCell(kt[mn]);
                        }
                        
                       
                    }
                }
                
                
            }
            document.Add(table);
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
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
