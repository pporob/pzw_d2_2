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
using pzw_d2_2.Controls;




namespace pzw_d2_2
{

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.Left.Click += new RoutedEventHandler(Left_Click);
            this.Right.Click += new RoutedEventHandler(Right_Click);

            RegisterUserDelete();
            RegisterPostDelete();

            RegisterUserEdit();
            RegisterPostEdit();

        }


        // POST EDIT

        private void RegisterPostEdit()
        {
            foreach (var child in this.CommentContainer.Children)
            {
                if (child is Post)
                {
                    var postItem = (Post)child;
                    postItem.Edit += new RoutedEventHandler(post_Edit);
                }
            }
        }


        void post_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post)) { return; }
            var postItem = (Post)sender;
            postItem.Comment = "";

        }



        // USER EDIT


        private void RegisterUserEdit()
        {
            foreach (var child in this.UserContainer.Children)
            {
                if (child is User)
                {
                    var userItem = (User)child;
                    userItem.Edit2 += new RoutedEventHandler(user_Edit);
                }
            }

            foreach (var child in this.Me.Children)
            {
                if (child is User)
                {
                    var userItem = (User)child;
                    userItem.Edit2 += new RoutedEventHandler(user_Edit);
                }
            }
        }


        void user_Edit(object sender, RoutedEventArgs e)
        {
            if (!(sender is User)) { return; }
            var userItem = (User)sender;
            userItem.Title = "";
        }





        // ADD USER

        void Left_Click(object sender, RoutedEventArgs e)
        {
            AddOrangeRectangle();
        }



        void AddOrangeRectangle()
        {
            User profile = new User();
            profile.Title = "New User";
            this.UserContainer.Children.Add(profile);
        }


        // ADD POST

        void Right_Click(object sender, RoutedEventArgs e)
        {
            AddRedRectangle();
        }


        void AddRedRectangle()
        {
            Post comment = new Post();
            comment.Title = "Me";
            comment.Comment = "New post";
            this.CommentContainer.Children.Add(comment);
        }


        // DELETE USER

        private void RegisterUserDelete()
        {
            foreach (var child in this.UserContainer.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Delete += new RoutedEventHandler(user_Delete);
                }
            }

            foreach (var child in this.Me.Children)
            {
                if (child is User)
                {
                    var user = (User)child;
                    user.Delete += new RoutedEventHandler(user_Delete);
                }
            }

        }

        void user_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is User))
            {
                return;
            }

            var user = (User)sender;
            this.UserContainer.Children.Remove(user);
            this.Me.Children.Remove(user);
        }


        // DELETE POST

        private void RegisterPostDelete()
        {
            foreach (var child in this.CommentContainer.Children)
            {
                if (child is Post)
                {
                    var post = (Post)child;
                    post.Delete += new RoutedEventHandler(post_Delete);
                }
            }
        }

        void post_Delete(object sender, RoutedEventArgs e)
        {
            if (!(sender is Post))
            {
                return;
            }

            var post = (Post)sender;
            this.CommentContainer.Children.Remove(post);
        }



    }
}
