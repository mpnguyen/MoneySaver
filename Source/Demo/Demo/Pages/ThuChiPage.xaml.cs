using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI;
using Windows.UI.Text;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Entity;
using BusLayer;
// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ThuChiPage : Page
    {
        public ThuChiPage()
        {
            this.InitializeComponent();
        }

        private void ThuChiPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            LoadThuChi();
        }

        private void LoadThuChi()
        {
            var business = new Bus();
            var listThu = business.GetListThu();
            if (listThu.Count == 0)
            {
                var status = new TextBlock()
                {
                    FontSize = 30,
                    FontStyle = FontStyle.Italic,
                    Foreground = new SolidColorBrush(Colors.DimGray),
                    TextWrapping = TextWrapping.Wrap,
                    Text = "Hiện chưa có giao dịch thu trong sổ thu chi"
                };
                ThuPanel.Children.Add(status);
            }
            else
            {
                ThuPanel.Children.Clear();
                foreach (var giaoDich in listThu)
                {
                    var giaoDichItem = new Button()
                    {
                        Content = giaoDich.Ten + "\n"
                                + giaoDich.SoTien.ToString() + " VND\n"
                                + giaoDich.Ngay.ToString() + "\n"
                                + giaoDich.NguoiThamGia + "\n"
                                + giaoDich.GhiChu,
                        Width = 300,
                        Margin = new Thickness(10, 10, 10, 10)
                    };
                    giaoDichItem.Click += GiaoDichItem_Click;
                    ThuPanel.Children.Add(giaoDichItem);
                }
            }

            var listChi = business.GetListChi();
            if (listChi.Count == 0)
            {
                var status = new TextBlock()
                {
                    FontSize = 30,
                    FontStyle = FontStyle.Italic,
                    Foreground = new SolidColorBrush(Colors.DimGray),
                    TextWrapping = TextWrapping.Wrap,
                    Text = "Hiện chưa có giao dịch chi trong sổ thu chi"
                };
                ChiPanel.Children.Add(status);
            }
            else
            {
                ChiPanel.Children.Clear();
                foreach (var giaoDich in listChi)
                {
                    var giaoDichItem = new Button()
                    {
                        Content = giaoDich.Ten + "\n"
                                + giaoDich.SoTien.ToString() + " VND\n"
                                + giaoDich.Ngay.ToString() + "\n"
                                + giaoDich.NguoiThamGia + "\n"
                                + giaoDich.GhiChu,
                        Width = 300,
                        Margin = new Thickness(10, 10, 10, 10)
                    };
                    giaoDichItem.Click += GiaoDichItem_Click;
                    ChiPanel.Children.Add(giaoDichItem);
                }
            }
        }
        private void GiaoDichItem_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button != null)
                button.Flyout = new Flyout
                {
                    Content = new StackPanel()
                    {
                        Children =
                        {
                            new Button() {Content = "Update", Width = 80, Height = 50, Margin = new Thickness(5)},
                            new Button() {Content = "Delete", Width = 80, Height = 50, Margin = new Thickness(5)}
                        }
                    }
                };
        }
    }
}
