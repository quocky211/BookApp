using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace TechieApp.Model
{
    public class SwipeDownToClosePopupPage : Behavior<View>
    {
        private PanGestureRecognizer PanGestureRecognizer { get; set; }
        private double TotalY { get; set; }
        private bool isSwipingDownOnComplete { get; set; }

        private double beforeY { get; set; }
        private double updatedY { get; set; }

        /// <summary>
        /// Close action, depends on your navigation mode
        /// </summary>
        public event Action CloseAction;

        public static BindableProperty CloseCommandProperty = BindableProperty.Create(nameof(CloseCommand)
            , typeof(ICommand
            ), typeof(SwipeDownToClosePopupPage)
            , null
            , defaultBindingMode: BindingMode.TwoWay
            , propertyChanged: (bindable, value, newValue) => ((SwipeDownToClosePopupPage)bindable).CloseCommand = (ICommand)newValue);
        public ICommand CloseCommand
        {
            get => (ICommand)GetValue(CloseCommandProperty);
            set => SetValue(CloseCommandProperty, value);
        }


        public static BindableProperty ParentViewProperty = BindableProperty.Create(nameof(ParentView)
            , typeof(Element
            ), typeof(SwipeDownToClosePopupPage)
            , null
            , defaultBindingMode: BindingMode.TwoWay
            , propertyChanged: (bindable, value, newValue) => ((SwipeDownToClosePopupPage)bindable).ParentView = (Element)newValue);
        public Element ParentView
        {
            get => (Element)GetValue(ParentViewProperty);
            set => SetValue(ParentViewProperty, value);
        }

        public SwipeDownToClosePopupPage()
        {
            PanGestureRecognizer = new PanGestureRecognizer();
        }

        protected override void OnAttachedTo(View v)
        {
            base.OnAttachedTo(v);
            PanGestureRecognizer.PanUpdated += Pan_PanUpdated;
            v.GestureRecognizers.Add(PanGestureRecognizer);
        }

        protected override void OnDetachingFrom(View v)
        {
            base.OnDetachingFrom(v);
            PanGestureRecognizer.PanUpdated -= Pan_PanUpdated;
            v.GestureRecognizers.Remove(PanGestureRecognizer);
        }

        private void Pan_PanUpdated(object sender, PanUpdatedEventArgs e)
        {
            View v = sender as View;
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    updatedY = beforeY = e.TotalY;
                    break;

                case GestureStatus.Running:
                    TotalY = e.TotalY;
                    updatedY = TotalY;
                    if (Device.RuntimePlatform == Device.Android)
                        isSwipingDownOnComplete = TotalY > 0;
                    else if (Device.RuntimePlatform == Device.iOS)
                        isSwipingDownOnComplete = updatedY > beforeY;
                    beforeY = updatedY;
                    if (TotalY > 0)
                    {
                        if (ParentView is View view)
                        {
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                view.TranslateTo(0, TotalY + view.TranslationY, 20, Easing.Linear);
                            }

                            else
                            {
                                view.TranslateTo(0, TotalY, 20, Easing.Linear);
                            }
                        }
                    }
                    else
                    {
                        if (ParentView is View view)
                        {
                            double moved = 0.0;
                            if (Device.RuntimePlatform == Device.Android)
                            {
                                moved = view.TranslationY + TotalY < 0 ? 0 : view.TranslationY + TotalY;
                            }
                            else
                            {
                                moved = TotalY < 0 ? 0 : TotalY;
                            }
                            view.TranslateTo(0, moved, 20, Easing.Linear);
                        }
                    }
                    break;
                case GestureStatus.Completed:
                    {
                        if (isSwipingDownOnComplete)
                        {
                            CloseAction?.Invoke();
                            CloseCommand?.Execute(null);
                        }
                        // Reset TranslateY
                        if (ParentView is View view)
                        {
                            view.TranslateTo(0, 0, 20, Easing.Linear);
                        }
                    }
                    break;

                case GestureStatus.Canceled:
                    {
                        // Reset TranslateY
                        if (ParentView is View view)
                        {
                            view.TranslateTo(0, 0, 20, Easing.Linear);
                        }
                    }
                    break;
            }

        }
    }
}
