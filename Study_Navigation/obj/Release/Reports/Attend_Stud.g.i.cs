﻿#pragma checksum "..\..\..\Reports\Attend_Stud.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "F6A42E97CD2347FD863A92F6A20BAFFB13F0A724B79C4D721224616A10AD4A3E"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Study_Navigation.Reports;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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


namespace Study_Navigation.Reports {
    
    
    /// <summary>
    /// Attend_StudAndGroups
    /// </summary>
    public partial class Attend_StudAndGroups : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Reports\Attend_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBack;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Reports\Attend_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExcelAdd;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\Reports\Attend_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Student;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Reports\Attend_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid Data;
        
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
            System.Uri resourceLocater = new System.Uri("/Study_Navigation;component/reports/attend_stud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reports\Attend_Stud.xaml"
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
            
            #line 10 "..\..\..\Reports\Attend_Stud.xaml"
            ((Study_Navigation.Reports.Attend_StudAndGroups)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GoBack = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Reports\Attend_Stud.xaml"
            this.GoBack.Click += new System.Windows.RoutedEventHandler(this.GoBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExcelAdd = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Reports\Attend_Stud.xaml"
            this.ExcelAdd.Click += new System.Windows.RoutedEventHandler(this.ExcelAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Student = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.Data = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

