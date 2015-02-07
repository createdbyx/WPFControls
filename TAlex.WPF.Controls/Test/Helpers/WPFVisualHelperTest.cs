﻿using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Xaml;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Controls;

using TAlex.WPF.Helpers;
using NUnit.Framework;


namespace TAlex.WPF.Controls.Test.Helpers
{
    [TestFixture]
    public class WPFVisualHelperTest
    {
        #region FindAncestor

        [Test]
        [STAThread]
        public void FindAncestor()
        {
            FrameworkElement visualTree = XamlServices.Parse(@"
                <Grid xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
		            <StackPanel Orientation=""Horizontal"">
			            <Image x:Name=""itemImage"" />
			            <TextBlock Text=""Some Text"" />
		            </StackPanel>
                </Grid>
                ") as FrameworkElement;

            DependencyObject foundElement = WPFVisualHelper.FindAncestor<Grid>(visualTree.FindName("itemImage") as DependencyObject);
            DependencyObject notFoundElement = WPFVisualHelper.FindAncestor<WrapPanel>(visualTree.FindName("itemImage") as DependencyObject);
            
            Assert.IsNotNull(foundElement);
            Assert.IsNull(notFoundElement);
        }

        [Test]
        public void FindAncestor_NotVisualElement()
        {
            DependencyObject visualTree = XamlServices.Parse(@"
                <Hyperlink xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
		            <Span>Some Text</Span>
                </Hyperlink>
                ") as DependencyObject;

            DependencyObject item = WPFVisualHelper.FindAncestor<TextBlock>(visualTree);
            Assert.IsNull(item);
        }

        #endregion
    }
}
