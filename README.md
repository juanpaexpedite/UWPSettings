# UWP Settings
Settings for UWP Applications

![Desktop Light Theme Example](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example1.jpg "Desktop Light Theme Example")

![Mobile Dark Theme Example](https://github.com/juanpaexpedite/UWPSettings/blob/master/Example2.jpg "Mobile Dark Theme Example")


## Introduction
The purpose of this small library is to organize in one place all the secondary content, settings and actions in a place similar like the OS Settings.

It is useful when having sections like Settings, About, Shortcuts, Help, Quests, Website, More apps, Rate, etc. and the app contains many places with buttons for those actions.

_All details are easy to understand in the ExamplesJobs.cs class_

## Basis

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

## To Do
1. Continue with new window settings panel.
2. Create a Configuration Manager to I/O values.
3. Create ViewModel for the example and watch values changing from settings to the view.
4. Implement Quests.
5. Implement Feedback.
6. Implement Badges.
7. Create more specific details sections.

## Third party libraries

In order to support markdown it is required the UWP Community Toolkit. In case you need to avoid it, you can remove easily the part of MarkDown.

## Support

If you found the library useful ☺, try and remove ads from any of my UWP apps you consider insteresting. I am preparing some of them and it will help to continue with them.

More information about my apps and development at [@juanpaexpedite](http://www.twitter.com/juanpaexpedite) and in my [blog](http://mareinsula.wordpress.com)