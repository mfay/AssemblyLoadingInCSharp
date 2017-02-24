# Assembly Loading Sample
This is just a contrived example of a plug-in system using reflection in c#.

## Projects
The project consists of three projects:
- LoadMeAnAssembly - Windows Application
- Filters - Class Library 
- ColorFilters - Class Library

### LoadMeAnAssembly
Simple application with a single reference to the Filters class library project.  Upon start up the application looks for IFilter types in the current executing assembly and loads them into the list box on the screen.  Additional filters can be added by dragging and dropping assemblies with filters that implement the IFilter interface.  You can select a filter from the list box and apply the filter with the Apply Filter button.

### Filters
Class Library with a single interface for IFilter.  I could have put this in the main application but I decided to break it out into another project.

### ColorFilters
Class Library with a reference to the Filters library.  It has a single filter implemented, RedFilter, that makes the image greyscale with a red tint.

### Demo
![Alt something](/docs/filter_demo.gif)