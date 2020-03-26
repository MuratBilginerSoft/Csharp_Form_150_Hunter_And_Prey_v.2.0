using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hunter_And_Prey
{
    public partial class Form1 : Form
    {
        #region Metodlar
        public void kutuoluştur()
        {
            kutular1[i] = new Kutu(i);
            kutular1[i].Click += kutu_Click;
            kutular1[i].MouseHover += kutu_MouseHover;
            kutular1[i].MouseLeave += kutu_MouseLeave;

            tableLayoutPanel1.Controls.Add(kutular1[i]);
            kutular1[i].Visible = true;
        }

        void kutu_MouseLeave(object sender, EventArgs e)
        {
            if (h1 == 0)
            {
                kutular1[h1 + 1].BackColor = Color.White;
                kutular1[h1 + 10].BackColor = Color.White;
                kutular1[h1 + 11].BackColor = Color.White;
            }
        }

        void kutu_MouseHover(object sender, EventArgs e)
        {
            if (h1==0)
            {
                kutular1[h1 + 1].BackColor = Color.CadetBlue;
                kutular1[h1 + 10].BackColor = Color.CadetBlue;
                kutular1[h1 + 11].BackColor = Color.CadetBlue;
            }
        }

        public void kuturenklerireset()
        {
            for (int i = 0; i < 100; i++)
            {
                kutular1[i].BackColor = Color.White;

            }
        }

        public void hunterişaretle()
        {
            kutular1[h1].BackColor = Color.Blue;
            kutular1[h1].ForeColor = Color.White;
            kutular1[h1].Text = "H";

            hx = kutular1[h1].Location.X;
            hy = kutular1[h1].Location.Y;
            lbl2.Text = hx.ToString();
            lbl3.Text = hy.ToString();

        }

        public void preyişaretle()
        {
            kutular1[p1].BackColor = Color.Red;
            kutular1[p1].ForeColor = Color.Black;
            kutular1[p1].Text = "P";

            px = kutular1[p1].Location.X;
            py = kutular1[p1].Location.Y;

            lbl4.Text = px.ToString();
            lbl5.Text = py.ToString();

        }

        public void huntertemizle()
        {
            kutular1[h1].BackColor = Color.Blue;
            kutular1[h1].ForeColor = Color.Black;
            kutular1[h1].Text = "";
        }

        public void preytemizle()
        {
            kutular1[p1].BackColor = Color.Red;
            kutular1[p1].ForeColor = Color.Black;
            kutular1[p1].Text = "";

        }
        
        public void uzaklıkhesapla()
        {
            uzaklık = Math.Sqrt(Math.Pow((hx - px), 2) + Math.Pow((hy - py), 2));
           
        }

        public void denemedeğer2()
        {

            px = kutular1[dpx].Location.X;
            py = kutular1[dpx].Location.Y;

            uzaklıkhesapla();

            if (uzaklık >= sonuzaklık)
            {
                sonuzaklık = uzaklık;
                dp[0] = dpx;
            }

            else sonuzaklık = ilkuzaklık;
        }
        
        public void hunterhareket()
        {
                    hareket++;
                    label1.Text = hareket.ToString();

                    huntertemizle();
                    h1 = h2;
                    hunterişaretle();
                    if (h1 == p1)
                    {
                        MessageBox.Show("Hunter Prey'i Yakaladı.","Tebrikler",MessageBoxButtons.OK,MessageBoxIcon.Information);
                        yenioyun();
                    }

                    else
                    {
                        uzaklıkhesapla();

                        ilkuzaklık = uzaklık;
                        sonuzaklık = uzaklık;
                        
                        if (uzaklık<125)
                        {
                            
                            #region Prey Sol Üst Köşede

                            // Prey in sol üst köşede olduğu an hareketi.

                            if (p1==0)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (i==0)
                                    {
                                         dpx = p1 + 1;

                                         denemedeğer2();
                                         
                                    }

                                    else if (i==1)
                                    {

                                        dpx = p1 + 10;

                                        denemedeğer2();

                                    }
                                    
                                }
                            }

                            #endregion

                            #region Prey Sağ Üst Köşede

                            else if (p1==9)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (i == 0)
                                    {
                                        dpx = p1 - 1;

                                        denemedeğer2();
                                    }

                                    else if (i == 1)
                                    {
                                        dpx = p1 + 10;

                                        denemedeğer2();
                                    }

                                }
                            }

                            #endregion

                            #region Prey Üst Tarafta

                            else if (p1==1 || p1==2 || p1==3 || p1==4 || p1==5 || p1==6 || p1==7 || p1==8 )
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (i==0)
                                    {
                                        dpx = p1 - 1;

                                        denemedeğer2();
                                    }

                                    else if (i==1)
                                    {
                                        dpx = p1 + 1;

                                        denemedeğer2();
                                    }

                                    else if (i==2)
                                    {
                                        dpx = p1 + 10;

                                        denemedeğer2();
                                    }
                                }
                            }

                            #endregion

                            #region Prey Sol Yan Tarafta

                            else if (p1==10 || p1==20 || p1==30 || p1==40 || p1==50 || p1==60 || p1==70 || p1==80 )
                            {
                                for (int i = 0; i < 3; i++)
                                {
                                    if (i == 0)
                                    {
                                        dpx = p1 - 10;

                                        denemedeğer2();
                                    }

                                    else if (i == 1)
                                    {
                                        dpx = p1 + 1;

                                        denemedeğer2();
                                    }

                                    else if (i == 2)
                                    {
                                        dpx = p1 + 10;

                                        denemedeğer2();
                                    }
                                }
                                
                            }

                            #endregion

                            #region Prey Sağ Yan Tarafta

                            else if (p1==19 || p1==29 || p1==39 || p1==49 || p1==59 || p1==69 || p1==79 || p1==89)
                            {
                                 for (int i = 0; i < 3; i++)
                                {
                                    if (i == 0)
                                    {
                                        dpx = p1 - 10;

                                        denemedeğer2();
                                    }

                                    else if (i == 1)
                                    {
                                        dpx = p1 - 1;

                                        denemedeğer2();
                                    }

                                    else if (i == 2)
                                    {
                                        dpx = p1 + 10;

                                        denemedeğer2();
                                    }
                                }
                            }


                            #endregion

                            #region Prey Sol Alt Köşede

                            else if (p1==90)
                            {
                                 for (int i = 0; i < 2; i++)
                                {
                                    if (i==0)
                                    {
                                         dpx = p1 -10;

                                         denemedeğer2();
                                         
                                    }

                                    else if (i==1)
                                    {

                                        dpx = p1 + 1;

                                        denemedeğer2();

                                    }
                                    
                                }
                            }

                            #endregion

                            #region Prey Sağ Alt Köşede

                            else if(p1==99)
                            {
                                for (int i = 0; i < 2; i++)
                                {
                                    if (i == 0)
                                    {
                                        dpx = p1 -10;

                                        denemedeğer2();

                                    }

                                    else if (i == 1)
                                    {

                                        dpx = p1 -1;

                                        denemedeğer2();

                                    }

                                }
                            }

                            #endregion
                                
                            #region Prey Alanda

                            else
                            {
                                for (int i = 0; i < 4; i++)
                                {
                                    if (i==0)
                                    {
                                        dpx = p1- 10;

                                        denemedeğer2();
                                    }

                                    else if (i==1)
                                    {
                                        dpx = p1- 1;

                                        denemedeğer2();
                                    }

                                    else if (i == 1)
                                    {
                                        dpx = p1 + 1;

                                        denemedeğer2();
                                    }

                                    else if (i == 1)
                                    {
                                        dpx = p1 + 10;

                                        denemedeğer2();
                                    }
                                }
                            }

                            #endregion
                            

                            preytemizle();

                            p1 = dp[0];

                            preyişaretle();

                         }
                       
                    }
                
        }

        public void yenioyun()
        {
            label5.Text = tur.ToString();

            kuturenklerireset();
            
            #region RastgeleDeğer

            h1 = r.Next(0, 100);

            do
            {
                p1 = r.Next(0, 100);
            } while (h1 == p1);
            
            #endregion

            hunterişaretle();

            preyişaretle();

            label2.Text = hareket.ToString();

            if (tur==2)
            {
                eniyiskor[0] = hareket;

            }

            else if (tur!=2)
            {
                if (hareket<=eniyiskor[0])
                {
                    eniyiskor[0] = hareket;
                }
            }

            hareket = 0;

            label1.Text = hareket.ToString();

            label4.Text = eniyiskor[0].ToString();

            tur++;

        }

        #endregion

        #region Tanımlamalar

        Random r = new Random(); // Rastgele değer üretecek.

        Kutu[] kutular1 = new Kutu[100]; // Kutu sınıfı nesnemizden dizi oluşturduk.

        int[] dp = new int[1]; // Deneme değerlerinde doğru Prey i tutacak dizi.



        int[] eniyiskor = new int[1];

        
        
        #endregion

        #region Değişkenler

        int hareket = 0;

        int h1; // Hunterin ilk değeri
        int h2; // Hunter ın tıklandıktan sonraki değeri.
        int h3; // Hunter için üst sınır kontrolünde aldığı değer.

        double hx; // Hunter ın X konumu
        double hy; // Hunter ın Y konumu
        
        int p1; // Prey in ilk değeri
       
        int dpx; // Prey in deneme değerleri.

        double px; // Prey in X konumu
        double py; // Prey in Y konumu

        int i; // Döngü değişkeni

        int tur = 1; // oyunun tur sayısını tutacak.

        double uzaklık; // Hunter ile Prey arasındaki mesafe

        double ilkuzaklık; // Mesafeyi ilk değer olarak alıyoruz.

        double sonuzaklık; // Mesafeyi son uzaklık olarak aldık.

        
        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
            #region Kutuları Oluştur

            for (i = 0; i < 100; i++)
            {
                kutuoluştur();
            }

            #endregion

            yenioyun();
           

        }

        private void kutu_Click(object sender, EventArgs e)
        {
            try
            {
                h2 = int.Parse((sender as Button).Name.Substring(3));

                #region Sınırın Üst Kısım Kontrolü

                if (h1==0 || h1==1 || h1==2 || h1==3 || h1==4 || h1==5 || h1==6 || h1==7 || h1==8 || h1==9)
                {
                    // Hunter duvarın en üst kısmıdamı öncelikle buna baktık. 

                    if (h1 == 9) // Hunter sınırın üst kısmının en sağındamı buna baktık.
                    {
                        if (  h1 - 1 == h2 || h1 == h2 || h1 + 9 == h2 || h1 + 10 == h2)
                        {
                            hunterhareket();
                        }
                    }

                    else if (h1 == 0) // Hunter sınırın üst kısmının sol köşesindemi buna baktık.
                    {
                        if ( h1 == h2 || h1 + 1 == h2 || h1 + 10 == h2 || h1 + 11 == h2)
                        {
                            hunterhareket();
                        }
                    }

                    else // Hunter sınırın üst kısmında ve köşelerde değilse çalışacak kodlar.
                    {
                        if (h1 - 1 == h2 || h1 == h2 || h1 + 1 == h2 || h1 + 9 == h2 || h1 + 10 == h2 || h1 + 11 == h2)
                        {
                            hunterhareket();
                        }
                    }
                }
                #endregion

                #region Sınırın Üst Kısımı Dışında Hunter
                else
                {
                    h3 = int.Parse(h1.ToString().Substring(1)); // Seçilen butonun değerinin son rakamını aldık.

                    if (h3 == 9) // Hunter üst sınır dışında sağ köşelerde ise.
                    {
                        h2 = int.Parse((sender as Button).Name.Substring(3)); // Seçilen butonun değerini aldık.

                        if (h1 - 11 == h2 || h1 - 10 == h2 || h1 - 1 == h2 || h1 == h2 || h1 + 9 == h2 || h1 + 10 == h2) // Hunter ın gidebileceği alanlara baktık
                        {
                            hunterhareket();
                        }
                    }

                    else if (h3 == 0) // Hunter üst sınır dışında sol köşelerde ise.
                    {
                        h2 = int.Parse((sender as Button).Name.Substring(3)); // Seçilen butonun değerini aldık.

                        if (h1 - 10 == h2 || h1 - 9 == h2 || h1 == h2 || h1 + 1 == h2 || h1 + 10 == h2 || h1 + 11 == h2)
                        {
                            hunterhareket();
                        }
                    }

                    else // Hunter üst sınır dışında bölge içinde ise.
                    {
                        h2 = int.Parse((sender as Button).Name.Substring(3)); // Seçilen butonun değerini aldık.

                        if (h1 - 11 == h2 || h1 - 10 == h2 || h1 - 9 == h2 || h1 - 1 == h2 || h1 == h2 || h1 + 1 == h2 || h1 + 9 == h2 || h1 + 10 == h2 || h1 + 11 == h2)
                        {
                            hunterhareket();
                        }
                    }
                }
                
                #endregion
            }

            catch (Exception)
            {

                MessageBox.Show("Opsss!!!","Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

           
        }
    }
}