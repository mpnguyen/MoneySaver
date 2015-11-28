using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.ServiceModel.Channels;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using BusLayer;
using Entity;
// The Content Dialog item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace Demo.Pages
{
    public sealed partial class AddDialog : ContentDialog
    {
        public AddDialog()
        {
            this.InitializeComponent();
        }

        private void ContentDialog_PrimaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
            var bus = new Bus();
            var temp = 0;

            var giaoDich = new GiaoDich()
            {
                Ten = TxtTenGd.Text,
                SoTien = int.Parse(TxtTien.Text),
                GhiChu = TxtGhiChu.Text,
                Ngay = DateTime.Parse(DpNgay.Date.ToString()),
                NguoiThamGia = TxtNguoiThamGia.Text,
                NhomGd = new NhomGD() { TenNhom = BoxNhomGd.SelectedValue.ToString() }
            };
            if (BoxLoaiGd.SelectedItem != null) bus.AddGiaoDich((LoaiGD) BoxLoaiGd.SelectedItem, giaoDich);

        }

        private void ContentDialog_SecondaryButtonClick(ContentDialog sender, ContentDialogButtonClickEventArgs args)
        {
        }

        private async void AddDialog_OnLoaded(object sender, RoutedEventArgs e)
        {
            var bus = new Bus();
            var listNhomGd = await bus.GetListNhomGd();
            foreach (var nhomGd in listNhomGd)
            {
                BoxNhomGd.Items?.Add(nhomGd.TenNhom);
            }
            
            BoxLoaiGd.Items.Add(LoaiGD.Thu);
            BoxLoaiGd.Items.Add(LoaiGD.Chi);
            BoxLoaiGd.Items.Add(LoaiGD.Vay);
            BoxLoaiGd.Items.Add(LoaiGD.ChoVay);
            BoxLoaiGd.Items.Add(LoaiGD.TietKiem);
            BoxNhomGd.SelectedIndex = 0;
            BoxLoaiGd.SelectedIndex = 0;
        }
    }
}
