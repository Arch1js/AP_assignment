﻿#pragma checksum "..\..\Manage Jobs.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "E31921599AD0B10EDD7338B6ECB11419"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using MahApps.Metro.Controls;
using MahApps.Metro.IconPacks;
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


namespace AP_assignment {
    
    
    /// <summary>
    /// Manage_Jobs
    /// </summary>
    public partial class Manage_Jobs : MahApps.Metro.Controls.MetroWindow, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal AP_assignment.Manage_Jobs App;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnHome;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbUser;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtSearchQuery;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDoingFilter;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnWaitingFilter;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUnresolvedFilter;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClear;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\Manage Jobs.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgJobs;
        
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
            System.Uri resourceLocater = new System.Uri("/AP_assignment;component/manage%20jobs.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Manage Jobs.xaml"
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
            this.App = ((AP_assignment.Manage_Jobs)(target));
            return;
            case 2:
            this.btnHome = ((System.Windows.Controls.Button)(target));
            
            #line 12 "..\..\Manage Jobs.xaml"
            this.btnHome.Click += new System.Windows.RoutedEventHandler(this.btnHome_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cmbUser = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 4:
            
            #line 14 "..\..\Manage Jobs.xaml"
            ((System.Windows.Controls.ComboBoxItem)(target)).Selected += new System.Windows.RoutedEventHandler(this.ComboBoxItem_Selected);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtSearchQuery = ((System.Windows.Controls.TextBox)(target));
            
            #line 24 "..\..\Manage Jobs.xaml"
            this.txtSearchQuery.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtSearchQuery_TextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnDoingFilter = ((System.Windows.Controls.Button)(target));
            
            #line 29 "..\..\Manage Jobs.xaml"
            this.btnDoingFilter.Click += new System.Windows.RoutedEventHandler(this.btnDoingFilter_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnWaitingFilter = ((System.Windows.Controls.Button)(target));
            
            #line 30 "..\..\Manage Jobs.xaml"
            this.btnWaitingFilter.Click += new System.Windows.RoutedEventHandler(this.btnWaitingFilter_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnUnresolvedFilter = ((System.Windows.Controls.Button)(target));
            
            #line 31 "..\..\Manage Jobs.xaml"
            this.btnUnresolvedFilter.Click += new System.Windows.RoutedEventHandler(this.btnUnresolvedFilter_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.btnClear = ((System.Windows.Controls.Button)(target));
            
            #line 32 "..\..\Manage Jobs.xaml"
            this.btnClear.Click += new System.Windows.RoutedEventHandler(this.btnClear_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.dgJobs = ((System.Windows.Controls.DataGrid)(target));
            
            #line 36 "..\..\Manage Jobs.xaml"
            this.dgJobs.CellEditEnding += new System.EventHandler<System.Windows.Controls.DataGridCellEditEndingEventArgs>(this.dgJobs_CellEditEnding);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Manage Jobs.xaml"
            this.dgJobs.AutoGeneratingColumn += new System.EventHandler<System.Windows.Controls.DataGridAutoGeneratingColumnEventArgs>(this.dgJobs_AutoGeneratingColumn);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Manage Jobs.xaml"
            this.dgJobs.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.dgJobs_PreviewKeyDown);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Manage Jobs.xaml"
            this.dgJobs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.dgJobs_SelectionChanged);
            
            #line default
            #line hidden
            
            #line 36 "..\..\Manage Jobs.xaml"
            this.dgJobs.BeginningEdit += new System.EventHandler<System.Windows.Controls.DataGridBeginningEditEventArgs>(this.dgJobs_BeginningEdit);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

