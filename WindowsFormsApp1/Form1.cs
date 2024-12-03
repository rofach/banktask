using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        string[] banks = { "private", "oschad" };
        Dictionary<string, ICard> cards = new Dictionary<string, ICard>();
        public Form1()
        {
            InitializeComponent();
            foreach(string bank in banks)
                comboBox1.Items.Add(bank);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string card = textBox1.Text;
                string bank = comboBox1.SelectedItem.ToString();
                if (banks.Contains(bank))
                {
                    if (listBox1.Items.Contains(card))
                        MessageBox.Show("карта вже існує");
                    else if(card == "") MessageBox.Show("помилка введення");
                    else
                    {
                        listBox1.Items.Add(textBox1.Text);
                        switch (bank)
                        {
                            case "private":
                                cards.Add(textBox1.Text, new PrivateBank(card));
                                break;
                            case "oschad":
                                cards.Add(textBox1.Text, new Oschad(card));
                                break;
                            default:
                                break;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("банка не існує");
                }
            }
            catch (FormatException) { MessageBox.Show("помилка"); }
            catch (NullReferenceException) { MessageBox.Show("помилка"); }     
            catch { MessageBox.Show("помилка"); }
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                int val = int.Parse(textBox3.Text);
                string card = listBox1.SelectedItem.ToString();
                cards[card].Add(val);
            }
            catch (FormatException)
            {
                MessageBox.Show("помилка");
            }
            catch 
            {
                MessageBox.Show("помилка");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                string card = listBox1.SelectedItem.ToString();
                MessageBox.Show($"balance: {cards[card].Balance.ToString()}\n" +
                    $"credit balance: {cards[card].CreditBalance.ToString()}\n" +
                    $"credit limit: {cards[card].CreditLimit.ToString()}\n");
            }
            catch
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                string card1 = textBox4.Text;
                string card2 = textBox5.Text;
                int val = int.Parse(textBox6.Text);
                if (cards.ContainsKey(card1) && cards.ContainsKey(card2))
                {
                    Operations.AddFromTo(cards[card1], cards[card2], val);
                }
                else
                {
                    MessageBox.Show("помилка");
                }
            }
            catch
            {
                MessageBox.Show("помилка");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                string card = listBox1.SelectedItem.ToString();
                int val = int.Parse(textBox7.Text);
                Operations.GetCredit(cards[card], val);
            }
            catch( ArgumentException)
            {
                MessageBox.Show("помилка");
            }
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                string card = listBox1.SelectedItem.ToString();
                int val = int.Parse(textBox8.Text);
                Operations.AddToCreditBal(cards[card], val);
            }
            catch (ArgumentException)
            {
                MessageBox.Show("помилка");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
