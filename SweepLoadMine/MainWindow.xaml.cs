using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections;
using System.Windows.Threading;
using System.Threading;
using SweepLoadMine.ServiceReference1;
using System.ServiceModel;
using System.ComponentModel;

namespace SweepLoadMine
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window, IService1Callback
    {
        private Service1Client client;
        public MainWindow()
        {
            InitializeComponent();
            this.Closing += MainWiondow_Closing;
        }

        private void MainWiondow_Closing(object sender, CancelEventArgs e)
        {
            if (client != null)
            {
                client.Logout(UserName);
                client.Close();
            }
        }


        private Border[,] backborder = new Border[10,10];

        Random r = new Random();             
        LoadMind loadMind;
        
       
        // 绘制带有地雷的格子
        private void CreatLoadMine()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    loadMind = new LoadMind();

                    loadMind.X = i;
                    loadMind.Y = j;

                    backborder[i, j] = new Border();
                    backborder[i, j].MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
                    backborder[i, j].MouseRightButtonDown += MainWindow_MouseRightButtonDown;
                    backborder[i, j].Background = Brushes.White;
                    backborder[i, j].BorderThickness = new Thickness(1);
                    backborder[i, j].BorderBrush = Brushes.Black;

                    backborder[i, j].Tag = loadMind;
                    backborder[i, j].Width = 60;
                    backborder[i, j].Height = 50;
                    Canvas.SetLeft(backborder[i, j], i * backborder[i, j].Width);
                    Canvas.SetTop(backborder[i, j], j * backborder[i, j].Height);
                    Map.Children.Add(backborder[i, j]);

                    Label label = new Label();
                    label.Width = backborder[i, j].Width;
                    label.Height = backborder[i, j].Height;
                    label.Content = "";
                    backborder[i, j].Child = label;
                }
            }          
        }

        // 随机雷的位置
        void Randon_mine()
        {
            for (int i = 0; i < 10; i++)
            {
                int col = r.Next(0, 10);
                int row = r.Next(0, 10);
                if (((LoadMind)backborder[col, row].Tag).Ismind == false)
                {
                    ((LoadMind)backborder[col, row].Tag).Ismind = true;
                }
                else
                {
                    i--;
                }

            }
        }


        //右键扫雷
        int flagNum =10;
        private void MainWindow_MouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border borders = (Border)sender;
         
            if (borders.Background==Brushes.White||(((Label)borders.Child).Content.ToString())=="")
            {
                if (((LoadMind)borders.Tag).Isflag == false)
                {
                    ImageBrush flag = new ImageBrush();                   
                     flag.ImageSource = new BitmapImage(new Uri(@"..\..\img\Map\flag.png", UriKind.Relative));
                    borders.Background = flag;
                    ((LoadMind)borders.Tag).Isflag = true;                   
                    if (flagNum > 0)
                    {
                        flagNum -= 1;
                        MindNum.Content = flagNum;
                    }
                    else
                    {
                        return;
                    }
                    MindNum.Content= flagNum;
                }
                else if (((LoadMind)borders.Tag).Isflag == true)
                {
                    borders.Background = Brushes.White;
                    ((LoadMind)borders.Tag).Isflag = false;
                    if (flagNum>=10)
                    {
                        flagNum = 10;
                    }
                    else
                    {
                        flagNum += 1;
                        MindNum.Content = flagNum;
                    }                   
                }            
            }
            else
            {
                return;
            }       
            //当所有的旗子都在地雷上面  游戏胜利
            if (((LoadMind)borders.Tag).Ismind==true&& Convert.ToInt32(MindNum.Content) == 0)
            {
               // MessageBox.Show("恭喜你！游戏胜利！");
                client.Win(UserName);
               // Map.Background = Brushes.White;
                return;
            }                                                                                                             
        }
        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            if (((LoadMind)border.Tag).Isflag==true)
            {
                return;
            }
            JudgeMind(border);                     
        }
        private void JudgeMind(Border border)
        {           
            LoadMind lm = ((LoadMind)border.Tag);           
            //如果是1就是雷
            if (lm.Ismind == true)
            {
                for (int i = 0; i < 10; i++)
                {
                    for (int j = 0; j < 10; j++)
                    {
                        if (((LoadMind)backborder[i, j].Tag).Ismind == true)
                        {
                            ImageBrush image = new ImageBrush();                           
                            image.ImageSource = new BitmapImage(new Uri(@"..\..\img\Map\mind.jpg", UriKind.Relative));
                            backborder[i, j].Background = image;
                        }
                    }
                }


                client.Fail(UserName);
                
                return;                                                                                                    
            }          
            else 
            {
                border.Background = Brushes.Gray;              
                //判界
                if (lm.Y - 1 >= 0 && ((LoadMind)backborder[lm.X, lm.Y - 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;                 
                }
                //
                if (lm.X - 1 >= 0 && lm.Y - 1 >= 0 && ((LoadMind)backborder[lm.X - 1, lm.Y - 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                   
                }
                if (lm.X - 1 >= 0 && ((LoadMind)backborder[lm.X - 1, lm.Y].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                    
                }
                if (lm.X - 1 >= 0 && lm.Y + 1 < 10 && ((LoadMind)backborder[lm.X - 1, lm.Y + 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                    
                }
                if (lm.Y + 1 < 10 && ((LoadMind)backborder[lm.X, lm.Y + 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                    
                }
                if (lm.X + 1 < 10 && lm.Y + 1 < 10 && ((LoadMind)backborder[lm.X + 1, lm.Y + 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                   
                }
                if (lm.X + 1 < 10 && ((LoadMind)backborder[lm.X + 1, lm.Y].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                   
                }
                if (lm.X + 1 < 10 && lm.Y - 1 >= 0 && ((LoadMind)backborder[lm.X + 1, lm.Y - 1].Tag).Ismind == true)
                {
                    //有雷 计数
                    //return;
                    lm.Count++;
                    
                }
                //左边
                if (lm.Y>0&&((LoadMind)backborder[lm.X, lm.Y - 1].Tag).Ismind == false&& backborder[lm.X, lm.Y - 1].Background==Brushes.White)
                {
                   
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X, lm.Y - 1]);
                    }
                }
                        
                //左上
                if (lm.X>0&&lm.Y>0&&((LoadMind)backborder[lm.X - 1, lm.Y - 1].Tag).Ismind == false && backborder[lm.X-1, lm.Y - 1].Background == Brushes.White)
                {
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X - 1, lm.Y - 1]);
                    }
                   
                }
              
                //上
                if (lm.X>0&&((LoadMind)backborder[lm.X - 1, lm.Y].Tag).Ismind == false && backborder[lm.X-1, lm.Y ].Background == Brushes.White)
                {
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X - 1, lm.Y]);
                    }
                    
                }
               
                //右上
                if (lm.X>0&&lm.Y<9&&((LoadMind)backborder[lm.X - 1, lm.Y + 1].Tag).Ismind == false && backborder[lm.X-1, lm.Y +1].Background == Brushes.White)
                {
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X - 1, lm.Y + 1]);
                    }
                  
                }
               
                //右边
                if (lm.Y<9&&((LoadMind)backborder[lm.X, lm.Y + 1].Tag).Ismind == false && backborder[lm.X, lm.Y + 1].Background == Brushes.White)
                {
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X, lm.Y + 1]);
                    }
                   
                }
               
                //右下
                if (lm.X<9&&lm.Y<9&&((LoadMind)backborder[lm.X + 1, lm.Y + 1].Tag).Ismind == false && backborder[lm.X+1, lm.Y + 1].Background == Brushes.White)
                {
                    if (lm.Count == 0)
                    {
                        JudgeMind(backborder[lm.X + 1, lm.Y + 1]);
                    }
                    
                }
               
                //下
                if (lm.X<9&&((LoadMind)backborder[lm.X + 1, lm.Y].Tag).Ismind == false && backborder[lm.X+1, lm.Y].Background == Brushes.White)
                {
                    if (lm.Count==0)
                    {
                        JudgeMind(backborder[lm.X + 1, lm.Y]);
                    }
                   
                }
               
                //左边下
                if (lm.X<9&&lm.Y>0&&((LoadMind)backborder[lm.X + 1, lm.Y - 1].Tag).Ismind == false && backborder[lm.X+1, lm.Y - 1].Background == Brushes.White)
                {
                    if (lm.Count==0)
                    {
                        JudgeMind(backborder[lm.X + 1, lm.Y - 1]);
                    }                    
                }                            
            }
            //总共的雷数量显示
            if (lm.Count>0)
            {            
                if (lm.Iskey==false)
                {
                    Label lb= (Label)border.Child;
                    lb.Content = lm.Count;
                    lb.HorizontalContentAlignment = HorizontalAlignment.Center;
                    lb.VerticalContentAlignment = VerticalAlignment.Center;
                    lb.FontSize = 28;
                    if (lb.Content.ToString()=="1")
                    {
                        lb.Foreground = Brushes.Red;
                    }
                    else if (lb.Content.ToString() == "2")
                    {
                        lb.Foreground = Brushes.Blue;
                    }
                    else if (lb.Content.ToString() == "3")
                    {
                        lb.Foreground = Brushes.Green;
                    }
                    else
                    {
                        lb.Foreground = Brushes.Purple;
                    }
                    lm.Iskey = true;
                }
                else if(lm.Iskey==true)
                {
                    return;
                }               
            }          
        }    
        private void Start_Click(object sender, RoutedEventArgs e)
        {
            Map.Children.Clear();    
            flagNum = 10;
            MindNum.Content = 10;              
            CreatLoadMine();
            Randon_mine();

            client.Start(UserName);
            start.IsEnabled = false;
        }

        private void Simple_Click(object sender, RoutedEventArgs e)
        {
            Map.Children.Clear();
            CreatLoadMine();
            for (int i = 0; i < 5; i++)
            {
                int col = r.Next(0, 10);
                int row = r.Next(0, 10);
                if (((LoadMind)backborder[col, row].Tag).Ismind == false)
                {
                    ((LoadMind)backborder[col, row].Tag).Ismind = true;
                }
                else
                {
                    i--;
                }
            }
            flagNum = 5;
            MindNum.Content = 5;
        }


        public string UserName
        {
            get { return userLogin.Text; }
            set { userLogin.Text = value; }
        }

        
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            UserName = userLogin.Text;
            InstanceContext context = new InstanceContext(this);
            client = new Service1Client(context);
            try
            {
                client.Login(userLogin.Text);
                loginBtn.IsEnabled = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("与服务端连接失败：" + ex.Message);
                return;
            }
        }

        private void AddMessage(string str)
        {
            TextBlock t = new TextBlock();
            t.Text = str;
            listbox.Items.Add(t);
        }

        #region 实现服务端指定的IRndGameServiceCallback接口

        public void ShowLogin(string loginUserName)
        { 
            AddMessage(loginUserName + "进入游戏。");
        }

        public void ShowStart(string userName)
        {
           AddMessage(userName+"已开始。");
        }

        public void ShowWin(string userName)
        {
            MessageBox.Show(userName + "已经获胜, 游戏结束 ，请双方重新开始。");
            AddMessage(userName + "已经获胜，"+"\n"+ "游戏结束,"+"\n"+"请双方重新开始。");
            Map.Children.Clear();
            Map.Background = Brushes.White;
            start.IsEnabled = true;
        }

        public void ShowFail(string userName)
        {
            MessageBox.Show(userName + "已经失败,游戏结束,请双方重新开始。");
            AddMessage(userName + "已经失败,"+"\n"+ "游戏结束,"+"\n"+"请双方重新开始。");
            Map.Children.Clear();
            Map.Background = Brushes.White;
            start.IsEnabled = true;
        }

        public void ShowLogout(string userName)
        {
            AddMessage(userName + "已退出。");
        }

        #endregion
    }
}
