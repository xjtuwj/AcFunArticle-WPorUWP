﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using AcFun.UWP.Model;

// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace AcFun.UWP.Pages
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class CommentListPage : Page
    {
        public CommentListPage()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.NavigationMode == NavigationMode.New)
            {
                var param = e.Parameter as CommentBindingModel;
                if (param != null)
                {
                    var list = new List<CommentBindingItemModel>();
                    var modelid = param.CommentId;
                    list.Add(param.CommentContentList[modelid]);
                    while (param.CommentContentList[modelid].ParentId > 0)
                    {
                        modelid = param.CommentContentList[modelid].ParentId;
                        list.Add(param.CommentContentList[modelid]);
                    }
                    list.Reverse();
                    CommentList.ItemsSource = list;
                }
            }
        }
    }
}