using System.Windows.Forms;

namespace GAPITranslator
{
    public partial class Form1 : Form
    {
        ComboBox cb;
        public Form1()
        {
            InitializeComponent();
            comboBox2.SelectedItem = "����������";
            comboBox1.SelectedItem = "�������";
            cb = new ComboBox();
            cb.Items.AddRange(new object[] {
                "���������������",
                "���������",
                "���������",
                "����������",
                "��������",
                "���������",
                "���������",
                "��������",
                "�����������",
                "�����������",
                "����������",
                "����������",
                "����������",
                "����������",
                "�����������",
                "���������� ����������",
                "�����������",
                "�����������",
                "���������",
                "����������",
                "���������",
                "�������",
                "����",
                "�����",
                "����",
                "����",
                "�������������",
                "����������",
                "����������",
                "���������",
                "�����������",
                "������",
                "�����",
                "�������",
                "�����������",
                "�����������",
                "������",
                "���������",
                "������������",
                "��������",
                "���������",
                "��������",
                "���������",
                "���������",
                "���������",
                "��������������",
                "�����������",
                "�������������",
                "���������",
                "��������",
                "�����������",
                "�����",
                "�������",
                "�����������",
                "����������� (����������)",
                "��������",
                "����������",
                "����������",
                "������� (������)",
                "���� (����)",
                "��������",
                "����������",
                "��������",
                "�������������",
                "�����",
                "���������",
                "�������",
                "����������",
                "��������",
                "������",
                "�����������",
                "������",
                "���������",
                "����������",
                "�����������",
                "�������",
                "����������",
                "����������",
                "����������",
                "�������",
                "����������",
                "�������",
                "������",
                "��������",
                "�����������",
                "���������",
                "���������",
                "����������",
                "����",
                "�������",
                "�����������",
                "��������",
                "�����",
                "�����",
                "����������",
                "����",
                "�������",
                "��������",
                "����",
                "����������� ��������",
                "���������",
                "���������",
                "��������",
                "��������" });
            richTextBox1.Text = string.Empty;
            richTextBox1.ForeColor = Color.Black;
            richTextBox1.Font = new Font("Segoe UI", 12);
            richTextBox1.Enter += RichTextBox1_Enter;
            richTextBox1.Leave += RichTextBox1_Leave;
            richTextBox1.TextChanged += RichTextBox1_TextChanged;
            richTextBox1.Paint += RichTextBox1_Paint;
        }
        private void RichTextBox1_Enter(object sender, EventArgs e)
        {
            if (richTextBox1.Text == "������� ����� ��� ��������...")
            {
                richTextBox1.Text = "";
                richTextBox1.ForeColor = Color.Black;
            }
        }
        private void RichTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.Text = "������� ����� ��� ��������...";
                richTextBox1.ForeColor = Color.Gray;
            }
        }
        private void RichTextBox1_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(richTextBox1.Text))
            {
                richTextBox1.ForeColor = Color.Black;
            }
            else
            {
                richTextBox1.ForeColor = Color.Gray;
            }
        }
        private void RichTextBox1_Paint(object sender, PaintEventArgs e)
        {
            if (string.IsNullOrEmpty(richTextBox1.Text))
            {
                using (Font font = new Font("Segoe UI", 12))
                using (Brush brush = new SolidBrush(Color.FromArgb(128, 169, 169, 169)))
                {
                    e.Graphics.DrawString("������� ����� ��� ��������...", font, brush, new Point(5, 5));
                }
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "�������";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = "����������";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "��������";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            comboBox2.SelectedItem = "���������";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cb.SelectedItem = comboBox1.SelectedItem;
            comboBox1.SelectedItem = comboBox2.SelectedItem;
            comboBox2.SelectedItem = cb.SelectedItem;
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                richTextBox2.Clear();
                string translatedText = await GoogleTranslate.TranslateAsync(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), richTextBox1.Text);
                richTextBox2.Text = translatedText;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "������! ����������� ��������-����������.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void �����ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void ����������ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("GAPI-Translator v1.0\n������� �� ������: https://translate.google.ru", "� ���������", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private async void richTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control && e.KeyCode == Keys.Enter)
            {
                try
                {
                    richTextBox2.Clear();
                    string translatedText = await GoogleTranslate.TranslateAsync(comboBox1.SelectedItem.ToString(), comboBox2.SelectedItem.ToString(), richTextBox1.Text);
                    richTextBox2.Text = translatedText;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "������! ����������� ��������-����������.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}

