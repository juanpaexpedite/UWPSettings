# UWP Settings
Settings for UWP Applications

![Desktop Light Theme Example](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example1.jpg "Desktop Light Theme Example")

![Mobile Dark Theme Example](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example2.jpg "Mobile Dark Theme Example")

## Release Notes
**V 0.2**
* WindowDialog
* SettingsPane
* Badges
* AchievementsPane
* Crostinis (In App Toasts) 


## Introduction
The purpose of this small library is to organize in one place all the secondary content, settings and actions in a place similar like the OS Settings.

It is useful when having sections like Settings, About, Shortcuts, Help, Quests, Website, More apps, Rate, etc. and the app contains many places with buttons for those actions.

_All details are easy to understand in the ExamplesJobs.cs class_


## Window Dialog

The Window Dialog is opened with the WindowManager, it contains the logic to open a modal content dialog with titlebar with an option to 'navigate' to a IsDetail section. You can set a header and icon header to simplify tasks.

    private async void LaunchExampleSeven()
    {
     var customcontrol = new CustomControl();
     await WindowManager.ShowWindowDialog(customcontrol,"Menu", "\uE734");
    }

## Crostinis (In App Toasts)

![Crostini Example](https://github.com/juanpaexpedite/UWPSettings/blob/master/CrostiniExample.jpg "Crostini Example")

Sometimes we need to show a toast, to show progress or a visual reaction of an action that is does not worth to show like a generic toast. In these situations you can use a Crostini that supports:

1. Show for a few seconds
2. Open in indeterminate mode and close by code
3. Show a Crostini with also an UIElement

In the Examples projects are detailed how it is used each, for instance:

    private async void LaunchExampleFour()
    {
     await Crostini.ShowNotification("File exported", icon: "\uE008", seconds: 4);
    }


## Badges

![Badges](https://github.com/juanpaexpedite/UWPSettings/blob/master/Badges.jpg "Badges")

The purpose is in future releases create quests instead of boring tutorials, and when the action to achieve a badge is done, you can set a Badge earned. 

_NOTE: The color is string with the hex value to be easy to store as data object_

As you can see it support several properties and is all XAML not a bitmap like the 'Feedback Hub' badges. 
You can choose the color you want or choose one Accent Color, You can look up the correspondence in UWP Technical guide -> Colors -> Accent, Download the app from the Store:
[UWP Techical guide](https://www.microsoft.com/store/apps/9nblggh5241d)

![Accent Colors](https://github.com/juanpaexpedite/UWPSettings/blob/master/Accentcolors.jpg "AccentColors")

Example on how to create a Badge:

    var badge = new Badge("Feedback phenom", "Submit 50 posts", Badge.StarNumbers.Three, true, DateTime.Now, ThemeColors.Orange16, "\uED15");

## Achievements Pane

You have the easy option tho launch a window dialog with the achievements pane that has a list of badges in few lines.

![Achievements](https://github.com/juanpaexpedite/UWPSettings/blob/master/Achievements.jpg "Achievements")

Example:

    private async void LaunchExampleSeven()
    {
       var list = ExampleJobs.SampleBadges();
       var achievements = new AchievementsPane();
       achievements.ItemsSource = list;
       await WindowManager.ShowWindowDialog(achievements,"Achievements", "\uE734");
    }

## Settings Pane

With the Settings class definition, you can create a List of them specifying per each:

  1. An Uri (website,rating,store, markdown file)
  2. A Type of UIElement for the Details.
  3. An Action of Setting, to customize the event.

## Features

1. Depending on the URI it will open the link in the webbrowser,the store or a valid link.
2. If the uri contains an ms-appx content with MarkDown (.md) file it will show a details element with the content.
3. If you specify a type of your app user controls, it will show in the details pane.
4. In case you want to create a custom action set it in the constructor of the Setting.
5. Responsive design with Visual States.
6. Dark and Light Theme aware.
7. _Experimental_ Open in a new Window.

![Details View](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example3.jpg "Details View")

![MarkDown View](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example4.jpg "MarkDown View")

-------------------------------------------------------------------------------------------------

## To Do
1. Navigate directly to details in settings
2. Create a Configuration Manager to I/O values.
3. Create ViewModel for the example and watch values changing from settings to the view.
4. Implement Quests.
5. Implement Feedback.
7. Create more specific details sections.

## Third party libraries

In order to support markdown it is required the UWP Community Toolkit. In case you need to avoid it, you can remove easily the part of MarkDown.

## Support

If you found the library useful ☺, you can donate here [donations](https://www.paypal.me/juanpaexpedite), Thank you!.

More information about my apps and development at [@juanpaexpedite](http://www.twitter.com/juanpaexpedite) and in my [blog](http://mareinsula.wordpress.com)


**You can donate here [donate](https://www.paypal.me/juanpaexpedite), Thank you!**
