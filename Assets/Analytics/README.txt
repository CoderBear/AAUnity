Analytics
---------


To use analytics, you will require a google analytics account. These are
free, and you can sign up at http://analytics.google.com/.

This package allows you to submit information to your google analytics
account from inside your game.

To use, simply add the Analytics component to a gameobject. This gameobject
will not be destroyed when you load a new level. Fill in the UA code (which
you get from your analytics account), the domain (which should be the same
as the one in your analytics account) and the application name, which 
should be unique for each game you wish to track.

To register an event, simply call the RegisterView(string title) method.
The Analytics components takes care of the rest, including session tracking
and individual game "visits" or plays.

