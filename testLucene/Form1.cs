using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;
using Lucene.Net.Analysis.PanGu;
using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace testLucene
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Analyzer analyzer = new PanGuAnalyzer();
            StringReader sr = new StringReader(textBox1.Text);
            TokenStream stream = analyzer.TokenStream(null, sr);
            
            bool hasNext = stream.IncrementToken();
            ITermAttribute ita = stream.GetAttribute<ITermAttribute>();
            StringBuilder sb = new StringBuilder();
            sb.Remove(0, sb.Length);
            string t1 = string.Empty;
            while (hasNext)
            {
                sb.Append(ita.Term + "\r\n");
                hasNext = stream.IncrementToken();
            }
            label1.Text = sb.ToString();
        }
    }
}
