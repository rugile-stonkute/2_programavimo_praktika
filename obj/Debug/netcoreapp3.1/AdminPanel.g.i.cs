﻿#pragma checksum "..\..\..\AdminPanel.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "D970197D6CBA4CBEA3BAF2F2FFEE0E43DD8E56E7"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Controls.Ribbon;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using _3_praktine;


namespace _3_praktine {
    
    
    /// <summary>
    /// AdminPanel
    /// </summary>
    public partial class AdminPanel : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminPasswordChangeButton;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox RegisteredUsersListBox;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminDeleteUserButton;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminChangePictureButton;
        
        #line default
        #line hidden
        
        
        #line 20 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AdminDeletePictureButton;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserOldPasswordCheckTextBox;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserNewPasswordCheckTextBox;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.PasswordBox UserNewPasswordTextBox;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\AdminPanel.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UserPictureImageBox;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/3_praktine;component/adminpanel.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AdminPanel.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.8.1.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.AdminPasswordChangeButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\AdminPanel.xaml"
            this.AdminPasswordChangeButton.Click += new System.Windows.RoutedEventHandler(this.AdminPasswordChangeButton_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.RegisteredUsersListBox = ((System.Windows.Controls.ListBox)(target));
            return;
            case 3:
            this.AdminDeleteUserButton = ((System.Windows.Controls.Button)(target));
            
            #line 18 "..\..\..\AdminPanel.xaml"
            this.AdminDeleteUserButton.Click += new System.Windows.RoutedEventHandler(this.AdminDeleteUserButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.AdminChangePictureButton = ((System.Windows.Controls.Button)(target));
            
            #line 19 "..\..\..\AdminPanel.xaml"
            this.AdminChangePictureButton.Click += new System.Windows.RoutedEventHandler(this.AdminChangePictureButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.AdminDeletePictureButton = ((System.Windows.Controls.Button)(target));
            
            #line 20 "..\..\..\AdminPanel.xaml"
            this.AdminDeletePictureButton.Click += new System.Windows.RoutedEventHandler(this.AdminDeletePictureButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.UserOldPasswordCheckTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 7:
            this.UserNewPasswordCheckTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 8:
            this.UserNewPasswordTextBox = ((System.Windows.Controls.PasswordBox)(target));
            return;
            case 9:
            this.UserPictureImageBox = ((System.Windows.Controls.Image)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

