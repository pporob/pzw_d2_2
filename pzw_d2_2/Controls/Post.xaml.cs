using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace pzw_d2_2.Controls
{
    /// <summary>
    /// Interaction logic for Post.xaml
    /// </summary>
    public partial class Post : UserControl
    {
        public Post()
        {
            InitializeComponent();

            this.DeletePost.MouseDown += new MouseButtonEventHandler(DeletePost_MouseDown);
            this.EditPost.MouseDown += new MouseButtonEventHandler(EditPost_MouseDown);

        }






        void DeletePost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseDeleteEvent();
        }


        public String Title
        {
            get { return (String)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(String), typeof(Post), new UIPropertyMetadata(""));



        public String Comment
        {
            get { return (String)GetValue(CommentProperty); }
            set { SetValue(CommentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CommentProperty =
            DependencyProperty.Register("Comment", typeof(String), typeof(Post), new UIPropertyMetadata(""));



        public static readonly RoutedEvent DeleteEvent = EventManager.RegisterRoutedEvent
        (
           "Delete", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );

        public event RoutedEventHandler Delete //za registraciju/deregistraciju 
        {
            add { AddHandler(DeleteEvent, value); }
            remove { RemoveHandler(DeleteEvent, value); }
        }

        void RaiseDeleteEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.DeleteEvent);
            RaiseEvent(newEventArgs);
        }




        void EditPost_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RaiseEditEvent();
        }

        public static readonly RoutedEvent EditEvent = EventManager.RegisterRoutedEvent
        (
            "Edit", //ime eventa
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(Post) //tip elementa koji posjeduje event
        );


        public event RoutedEventHandler Edit //za registraciju/deregistraciju
        {
            add { AddHandler(EditEvent, value); }
            remove { RemoveHandler(EditEvent, value); }
        }


        void RaiseEditEvent()
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(Post.EditEvent);
            RaiseEvent(newEventArgs);
        }






    }
}
