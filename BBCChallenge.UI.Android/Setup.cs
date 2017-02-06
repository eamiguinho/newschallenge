using System;
using Android.Content;
using Android.Webkit;
using Android.Widget;
using BBCChallenge.Core.Interfaces.PlatformSpecific;
using BBCChallenge.DataServices.Local;
using BBCChallenge.DataServices.Online;
using BBCChallenge.Domain.Implementation;
using BBCChallenge.Services.Implementation;
using BBCChallenge.UI.Android.Services;
using BBCChallenge.UI.ViewModels;
using MvvmCross.Binding.Bindings.Target;
using MvvmCross.Binding.Bindings.Target.Construction;
using MvvmCross.Binding.Droid;
using MvvmCross.Binding.Droid.Target;
using MvvmCross.Core.ViewModels;
using MvvmCross.Droid.Platform;
using MvvmCross.Platform;
using Square.Picasso;

namespace BBCChallenge.UI.Android
{
    public class Setup : MvxAndroidSetup
    {
        public Setup(Context applicationContext) : base(applicationContext)
        {
          
        }
        protected override MvxAndroidBindingBuilder CreateBindingBuilder()
        {
            return new MyAndroidBindingBuilder();
        }

        public class MyAndroidBindingBuilder : MvxAndroidBindingBuilder
        {
            protected override void FillTargetFactories(IMvxTargetBindingFactoryRegistry registry)
            {
                base.FillTargetFactories(registry);

                registry.RegisterCustomBindingFactory<ImageView>("ImageSource",
                                                     imageView => new MvxVideoViewUriTargetBinding(imageView));

                registry.RegisterCustomBindingFactory<WebView>("Url",
                                                   imageView => new MvxWebViewUrlTargetBinding(imageView));

            }
        }

        protected override IMvxApplication CreateApp()
        {
            Mvx.RegisterSingleton<IPlatformSpecificService>(new PlatformSpecificService());
            IoCDomain.Register();
            IoCLocalDataService.Register();
            IoCOnlineDataService.Register();
            IoCService.Register();
            return new App();
        }
    }

    public class MvxWebViewUrlTargetBinding : MvxAndroidTargetBinding
    {
        public MvxWebViewUrlTargetBinding(object target) : base(target)
        {
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        protected override void SetValueImpl(object target, object value)
        {
            if (target != null && value != null)
            {
                var webview = target as WebView;
                webview?.LoadUrl(value as string);
            }
        }
    }

    public class MvxVideoViewUriTargetBinding : MvxAndroidTargetBinding
    {
        public MvxVideoViewUriTargetBinding(object target) : base(target)
        {
        }

        public override Type TargetType
        {
            get { return typeof(string); }
        }

        protected override void SetValueImpl(object target, object value)
        {
            if (target != null && value != null)
            {
               var imageView = (ImageView)target;
            Picasso.With(imageView.Context)
     .Load(value as string).Fit().Into(imageView);
            }
        }
    }
}