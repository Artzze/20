using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace эээ
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void AboutClick(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Создатель: Журавлев\nВариант 7\nПрактическая 20: Генерировать случайные числа Х, распределенные в диапазоне от -1 до 6 и вычислять для чисел > 0 Корень(X), а для чисел < 0 функцию x^2. Вычисления прекратить, когда подряд появится два одинаковых случайных числа. На экран необходимо выводить сгенерированное число и результат расчета функции на разных строках.", "О программе");
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            Otv.Clear();
            RndNums.Items.Clear();
        }

        private void Raschet(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < RndNums.Items.Count; i++)
            {
                if (Convert.ToInt32(RndNums.Items[i]) > 0) 
                {
                    Otv.Text += Math.Sqrt(Convert.ToInt32(RndNums.Items[i])).ToString("0.00") + "\n";
                }
                if (Convert.ToInt32(RndNums.Items[i]) < 0)
                {
                    Otv.Text += Math.Pow(Convert.ToInt32(RndNums.Items[i]), 2) + "\n";
                }
            }
        }

        private void RandomInput(object sender, RoutedEventArgs e)
        {
            if (RndAmount.Text != "")
            {
                bool f = int.TryParse(RndAmount.Text, out int x);
                if (f)
                {
                    if (x > 0)
                    {
                        int proverka = 0, a = 7;
                        Random rnd = new Random();
                        do
                        {
                            int proverkaList = RndNums.Items.Count;
                                proverka = a;
                                a = rnd.Next(-1, 6);
                                RndNums.Items.Add(a);
                                x -= 1;
                        } while (x > 0 && proverka != a);
                    }
                    else
                    {
                        MessageBox.Show("Количество не может быть нулевым или отрицательным", "Ошибка");
                    }
                }
                else
                {
                    MessageBox.Show("Необходимо вводить числа", "Ошибка");
                }
            }
            else
            {
                return;
            }
        }

        private void DeleteList(object sender, RoutedEventArgs e)
        {
            if (RndNums.SelectedIndex != -1)
            {
                RndNums.Items.RemoveAt(RndNums.SelectedIndex);
            }
            else
            {
                return;
            }
        }
    }
}