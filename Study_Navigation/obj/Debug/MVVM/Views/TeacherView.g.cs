﻿#pragma checksum "..\..\..\..\MVVM\Views\TeacherView.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "3DC146DEDE3A2B56E14ECF739A115992F0639B08F2229A52C42ECA12ADFF4758"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using Study_Navigation.MVVM.ViewModel;
using Study_Navigation.MVVM.Views;
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


namespace Study_Navigation.MVVM.Views {
    
    
    /// <summary>
    /// TeacherView
    /// </summary>
    public partial class TeacherView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 22 "..\..\..\..\MVVM\Views\TeacherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DataGroup;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\MVVM\Views\TeacherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DataStudents;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\MVVM\Views\TeacherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Attend_StudAndGroups;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\MVVM\Views\TeacherView.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Perf_StudAndGroups;
        
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
            System.Uri resourceLocater = new System.Uri("/Study_Navigation;component/mvvm/views/teacherview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\MVVM\Views\TeacherView.xaml"
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
            this.DataGroup = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\..\MVVM\Views\TeacherView.xaml"
            this.DataGroup.Click += new System.Windows.RoutedEventHandler(this.DataGroup_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.DataStudents = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\..\MVVM\Views\TeacherView.xaml"
            this.DataStudents.Click += new System.Windows.RoutedEventHandler(this.DataStudents_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.Attend_StudAndGroups = ((System.Windows.Controls.Button)(target));
            
            #line 66 "..\..\..\..\MVVM\Views\TeacherView.xaml"
            this.Attend_StudAndGroups.Click += new System.Windows.RoutedEventHandler(this.Attend_StudAndGroups_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Perf_StudAndGroups = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\MVVM\Views\TeacherView.xaml"
            this.Perf_StudAndGroups.Click += new System.Windows.RoutedEventHandler(this.Perf_StudAndGroups_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

