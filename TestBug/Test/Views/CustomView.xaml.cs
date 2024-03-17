using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.Controls.Xaml;
using Microsoft.Maui.Layouts;
using Microsoft.Maui.Graphics;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using Microsoft.Maui.Controls.Internals;
using View = Microsoft.Maui.Controls.View;


namespace TestZone.Test.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CustomView : Microsoft.Maui.Controls.ContentView
    {
        private float ratioX = 0.364f;
        private float ratioY = 0.364f;

        private int paddingLeft = 50;
        private int paddingRight = 50;

        #region ItemTemplate

        public static void initPropertyItemTemplate(BindableObject bindable, object oldValue, object newValue)
        {
            CustomView view = (CustomView)bindable;
            view.ItemTemplate = (DataTemplate)newValue;
            //view.init();
        }

        public static readonly BindableProperty ItemTemplateProperty = BindableProperty.Create(nameof(ItemTemplate), typeof(DataTemplate), typeof(CustomView), propertyChanged: initPropertyItemTemplate);

        public DataTemplate ItemTemplate
        {

            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set => SetValue(ItemTemplateProperty, value);
        }

        #endregion ItemTemplate

        #region ItemsSource
        /*
        public static void initPropertyItemSource(BindableObject bindable, object oldValue, object newValue)
        {
           
            CustomView view = (CustomView)bindable;
//            view.ItemsSource = (IEnumerable<INode>)newValue;
            //view.init();
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource), typeof(IEnumerable<INode>), typeof(TreeView2), null, propertyChanged : initPropertyItemSource);
        *//*
        public IEnumerable<INode> ItemsSource
        {
            get => (IEnumerable<INode>)GetValue(ItemsSourceProperty);
            set  {
                SetValue(ItemsSourceProperty, value);                
            }
        }
        */
        #endregion ItemsSource


        public Rect _absoluteLayoutBounds { get; set; } = new Rect();
        public Rect CustomLayout { get { return _absoluteLayoutBounds; } set { _absoluteLayoutBounds = value; OnPropertyChanged(); } }

        public static readonly BindableProperty NameProperty = BindableProperty.Create(nameof(Name), typeof(String), typeof(CustomView), null);

        public String Name
        {
            get { return (String)GetValue(NameProperty); }
            set { SetValue(NameProperty, value); init(); }
        }

        private bool isInit = false;

        public CustomView()
        {
            InitializeComponent();
            this.BindingContext = this;

            if (this.ItemTemplate == null)
            {
                Console.WriteLine("TREE VIEW", "ITEMS TEMPLATE NULL");
            }
        }

     


        public void init()
        {
            Console.WriteLine("TEST IF INIT : " + Name + " init ");
            isInit = true;
            /*if (this.ItemsSource == null)
            {
                isInit = false;
            }*/

            if (this.ItemTemplate == null)
            {
                isInit = false;
            }

            if (isInit) {
                Console.WriteLine("START INIT : " + Name + " init ");

            }
        }

        private void Layout_SizeChanged(object sender, EventArgs e)
        {
            init();
            Console.WriteLine("LOAD : " + Name + " init ");
        }
    }


}