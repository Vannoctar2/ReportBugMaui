using Microsoft.Maui.Graphics;
using SkiaSharp.Views.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui;
using SkiaSharp;
using System;
using SkiaSharp.Views.Maui.Controls;


namespace TestZone.Test.Views
{
    public class MyCanvasView : SKCanvasView
    {
        #region Constructors
        private float lastXTouch = -1, lastYTouch = -1;
        private bool isPressed;
        public MyCanvasView()
        {
            BackgroundColor = Colors.Transparent;
            PaintSurface += OnPaintCanvas;
            EnableTouchEvents = true;

        }


        public event EventHandler<SKPaintSurfaceEventArgs> ChartPainted;

        #endregion

        #region Static fields

        public static readonly BindableProperty DrawerProperty = BindableProperty.Create(nameof(Drawer), typeof(CanvasDrawer), typeof(MyCanvasView), null, propertyChanged: OnChartChanged);

        #endregion

        #region Fields

        private CanvasDrawer drawer;

        #endregion

        #region Properties

        public CanvasDrawer Drawer
        {
            get { return (CanvasDrawer)GetValue(DrawerProperty); }
            set { SetValue(DrawerProperty, value); }
        }

        #endregion

        #region Methods

        private static void OnChartChanged(BindableObject d, object oldValue, object value)
        {
            var view = d as MyCanvasView;
            view.drawer = value as CanvasDrawer;
            view.InvalidateSurface();

        }

        private bool FirstPaint = true;
        private void OnPaintCanvas(object sender, SKPaintSurfaceEventArgs e)
        {
            if (drawer != null)
            {
                if (FirstPaint)
                {
                    FirstPaint = false;
                }
                drawer.Draw(e.Surface.Canvas);
            }
            else
            {
                e.Surface.Canvas.Clear(SKColors.Transparent);
            }

            ChartPainted?.Invoke(sender, e);
        }


        #endregion
    }
}