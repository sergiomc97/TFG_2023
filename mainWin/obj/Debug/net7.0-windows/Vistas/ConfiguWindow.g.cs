﻿#pragma checksum "..\..\..\..\Vistas\ConfiguWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "24243BB3A2D0784655CA8152BAE7FE2A67C80562"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome.WPF;
using FontAwesome.WPF.Converters;
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
using mainWin.Vistas;


namespace mainWin.Vistas {
    
    
    /// <summary>
    /// ConfiguWindow
    /// </summary>
    public partial class ConfiguWindow : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 23 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid control;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid expandedContent;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button backBtn;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtRutaArchivo;
        
        #line default
        #line hidden
        
        
        #line 129 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox combo2;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button asign;
        
        #line default
        #line hidden
        
        
        #line 176 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button cargar;
        
        #line default
        #line hidden
        
        
        #line 192 "..\..\..\..\Vistas\ConfiguWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/mainWin;component/vistas/configuwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 13 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            ((System.Windows.Controls.Grid)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Grid_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.control = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.expandedContent = ((System.Windows.Controls.Grid)(target));
            return;
            case 4:
            this.backBtn = ((System.Windows.Controls.Button)(target));
            
            #line 60 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            this.backBtn.Click += new System.Windows.RoutedEventHandler(this.backBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.txtRutaArchivo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            
            #line 105 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.SeleccionarArchivo_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.combo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.combo2 = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 9:
            this.asign = ((System.Windows.Controls.Button)(target));
            
            #line 155 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            this.asign.Click += new System.Windows.RoutedEventHandler(this.asign_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.cargar = ((System.Windows.Controls.Button)(target));
            
            #line 183 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            this.cargar.Click += new System.Windows.RoutedEventHandler(this.cargar_Click);
            
            #line default
            #line hidden
            return;
            case 11:
            this.SaveButton = ((System.Windows.Controls.Button)(target));
            
            #line 194 "..\..\..\..\Vistas\ConfiguWindow.xaml"
            this.SaveButton.Click += new System.Windows.RoutedEventHandler(this.SaveButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

