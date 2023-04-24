import tkinter as tk 

class GuiBuilder:
    def __init__(self):
        self.widgets = [] # list to hold widget settings

    def add_widget(self, widget_type, **kwargs):
        """add a new widget to the canvas with the specified settings."""
        # create the widget
        widget = widget_type(self.canvas, **kwargs)
        # store its settings in the list
        self.widgets.append({"type": str(widget_type), "settings": kwargs})
        # bind the widget to allow it to be dragged and dropped 
        widget.bind("<Button-1>", self.start_dragging)
        widget.bind("<B1-Motion>", self.move_widget)

    def start_dragging(self, event):
        """Record the starting position of the widget being dragged"""
        widget = event.widget
        self.dragging = {"widget": widget, "x": event.x, "y": event.y}
    
    def move_widget(self, event):
        """move the widget being dragged"""
        widget = self.dragging["widget"] 
        dx = event.x - self.dragging["x"]
        dy = event.y - self.dragging["y"]
        x, y = self.canvas.coords(widget)

        self.canvas.coords(widget, x + dx, y + dy)
        self.dragging["x"] = event.x
        self.dragging["y"] = event.y

    def get_code(self):
        """generate python code based on the widgets added"""
        widget_code = ""
        for widget in self.widgets:
            widget_code += f"\n{widget['type']}(self.canvas, **{widget['settings']})"

        code_template = f"""import tkinter as tk

class MyGui:
    def __init__(self, master):
        self.canvas = tk.Canvas(master, width=400, height=400, bg="white")
        self.canvas.pack()

        {widget_code}

root = tk.Tk()
gui = MyGui(root)
root.mainloop()
"""

        return code_template

    def create_gui(self):
        """create the gui and start the tkinter event loop"""
        self.root = tk.Tk()
        self.canvas = tk.Canvas(self.root, width=400, height=400, bg="white")
        self.canvas.pack()

        # add some demo widgets
        self.add_widget(tk.Label, text="Hello World1", fg="red", bg="white")
        self.add_widget(tk.Button, text="click me", command=self.button_clicked)

        # add the submit button
        submit_button = tk.Button(self.root, text="submit", command=self.show_code)
        submit_button.pack()

        # ensure that the button and label widgets always appear on the canvas
        for widget in self.widgets:
            widget_type = getattr(tk, widget["type"], None)
            if widget_type and widget_type in (tk.Label, tk.Button):
                widget_type(self.canvas, **widget["settings"])

        self.root.mainloop()

    def show_code(self):
        """display the generated code to the user."""
        code = self.get_code()
        code_dialog = tk.Toplevel(self.root)
        code_text = tk.Text(code_dialog)
        code_text.insert(tk.END, code)
        code_text.pack()

    def button_clicked(self):
        """ a demo function to show how button events can be handled"""
        print("button clicked")


builder = GuiBuilder()
builder.create_gui()
