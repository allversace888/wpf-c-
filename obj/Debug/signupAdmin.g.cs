﻿#pragma checksum "..\..\signupAdmin.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "AEF196509BEDE59222C613FFBAC2539DE1EF083A56AA7CFD4CD23DFBF9E26F17"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
using sql;


namespace sql {
    
    
    /// <summary>
    /// signupAdmin
    /// </summary>
    public partial class signupAdmin : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 25 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox loginBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordBox;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox passwordBoxRepeat;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SecondName;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox FirstName;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Surname;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\signupAdmin.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox NumberPhone;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/sql;component/signupadmin.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\signupAdmin.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.loginBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.passwordBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.passwordBoxRepeat = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.SecondName = ((System.Windows.Controls.TextBox)(target));
            
            #line 28 "..\..\signupAdmin.xaml"
            this.SecondName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.SecondName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 5:
            this.FirstName = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\signupAdmin.xaml"
            this.FirstName.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.FirstName_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Surname = ((System.Windows.Controls.TextBox)(target));
            
            #line 30 "..\..\signupAdmin.xaml"
            this.Surname.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.Surname_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 7:
            this.NumberPhone = ((System.Windows.Controls.TextBox)(target));
            
            #line 31 "..\..\signupAdmin.xaml"
            this.NumberPhone.PreviewTextInput += new System.Windows.Input.TextCompositionEventHandler(this.NumberPhone_PreviewTextInput);
            
            #line default
            #line hidden
            return;
            case 8:
            
            #line 33 "..\..\signupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.CloseBtn);
            
            #line default
            #line hidden
            return;
            case 9:
            
            #line 34 "..\..\signupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.RegistrationAccount);
            
            #line default
            #line hidden
            return;
            case 10:
            
            #line 35 "..\..\signupAdmin.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.LoginAccount);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

