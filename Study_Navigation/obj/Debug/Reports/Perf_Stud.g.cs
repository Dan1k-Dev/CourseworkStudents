﻿#pragma checksum "..\..\..\Reports\Perf_Stud.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "995816CAC9D1EE7DA5CC0CB315147C627079CD605F6C91F7B9A31E25AD88C4DD"
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
    /// PerfStud_adm
    /// </summary>
    public partial class PerfStud_adm : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button GoBack;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button ExcelAdd;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Add_data;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Edit_data;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Update;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\..\Reports\Perf_Stud.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Stud;
        
        #line default
        #line hidden
        
        
        #line 103 "..\..\..\Reports\Perf_Stud.xaml"
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
            System.Uri resourceLocater = new System.Uri("/Study_Navigation;component/reports/perf_stud.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Reports\Perf_Stud.xaml"
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
            
            #line 10 "..\..\..\Reports\Perf_Stud.xaml"
            ((Study_Navigation.Reports.PerfStud_adm)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.GoBack = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\..\Reports\Perf_Stud.xaml"
            this.GoBack.Click += new System.Windows.RoutedEventHandler(this.GoBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ExcelAdd = ((System.Windows.Controls.Button)(target));
            
            #line 41 "..\..\..\Reports\Perf_Stud.xaml"
            this.ExcelAdd.Click += new System.Windows.RoutedEventHandler(this.ExcelAdd_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Add_data = ((System.Windows.Controls.Button)(target));
            
            #line 53 "..\..\..\Reports\Perf_Stud.xaml"
            this.Add_data.Click += new System.Windows.RoutedEventHandler(this.Add_data_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Edit_data = ((System.Windows.Controls.Button)(target));
            
            #line 65 "..\..\..\Reports\Perf_Stud.xaml"
            this.Edit_data.Click += new System.Windows.RoutedEventHandler(this.Edit_data_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Update = ((System.Windows.Controls.Button)(target));
            
            #line 77 "..\..\..\Reports\Perf_Stud.xaml"
            this.Update.Click += new System.Windows.RoutedEventHandler(this.Update_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.Stud = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.Data = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

