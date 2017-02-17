This control was originally written by [Quinn Damerell](https://github.com/QuinnDamerell) and [Paul Bartrum](https://github.com/paulbartrum) for [Baconit](https://github.com/QuinnDamerell/Baconit), a popular open source reddit UWP. The control *almost* supports the full markdown syntax, with a focus on super-efficient parsing and rendering. The control is efficient enough to be used in virtualizing lists.

&nbsp;

*Note:* For a full list of markdown syntax, see the [official syntax guide](http://daringfireball.net/projects/markdown/syntax).

&nbsp;

**Try it live!** Type in the *unformatted text box* above!

&nbsp;

# PARAGRAPHS

Paragraphs are delimited by a blank line.  Simply starting text on a new line won't create a new paragraph; It will remain on the same line in the final, rendered version as the previous line.  You need an extra, blank line to start a new paragraph.  This is especially important when dealing with quotes and, to a lesser degree, lists.

You can also add non-paragraph line breaks by ending a line with two spaces.  The difference is subtle:

Paragraph 1, Line 1  
Paragraph 1, Line 2  

Paragraph 2

*****

# FONT FORMATTING
### Italics

Text can be displayed in an italic font by surrounding a word or words with either single asterisks (\*) or single underscores (\_).

For example: 

>This sentence includes \*italic text\*.

is displayed as:

>This sentence includes *italic text*.

