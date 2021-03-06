﻿using CPAS.Models;
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

namespace CPAS.UserCtrl
{
    /// <summary>
    /// UC_CamViewListItem.xaml 的交互逻辑
    /// </summary>
    public partial class UC_CamViewListItem : UserControl
    {
        public UC_CamViewListItem()
        {
            InitializeComponent();
        }
        public int CurCamID
        {
            get
            {
                return Convert.ToInt16(GetValue(CurCamIDProperty));
            }
            set {
                SetValue(CurCamIDProperty,value);
            }
        }
        public static DependencyProperty CurCamIDProperty = DependencyProperty.Register("CurCamID", typeof(int), typeof(UC_CamViewListItem));

        private void BtnAdd_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RoiModelBase;
            if (CurCamID < 0)
            {
                UC_MessageBox.ShowMsgBox("请选择一个相机进行操作");
                return;
            }
            vm.Index = CurCamID;
            vm.OperateAdd.Execute(vm);
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var vm = DataContext as RoiModelBase;
            if (CurCamID < 0)
            {
                UC_MessageBox.ShowMsgBox("请选择一个相机进行操作");
                return;
            }
            vm.Index = 2;// CurCamID;
            vm.OperateDelete.Execute(vm);
        }
    }
}
