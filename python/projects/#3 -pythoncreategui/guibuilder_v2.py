import tkinter as tk

class DraggableButton(tk.Button):
    def __init__(self, parent, **kwargs):
        super().__init__(parent, **kwargs)
        self.bind("<ButtonPress-1>", self.on_button_press)
        self.bind("<B1-Motion>", self.on_button_motion)
        self.bind("<ButtonRelease-1>", self.on_button_release)
        self.current_object = None
        self.start_x = None
        self.start_y = None

    def on_button_press(self, event):
        self.current_object = event.widget
        self.start_x = event.x
        self.start_y = event.y

    def on_button_motion(self, event):
        x = self.winfo_x() - self.start_x + event.x
        y = self.winfo_y() - self.start_y + event.y
        self.place(x=x, y=y)

    def on_button_release(self, event):
        self.current_object = None
        self.start_x = None
        self.start_y = None

class GUI_Builder:
    def __init__(self):
        self.root = tk.Tk()
        self.root.title("GUI Builder")

        # Create a toolbar with buttons and other GUI objects
        self.toolbar = tk.Frame(self.root, bg="white", bd=1, relief=tk.RAISED)
        self.button = DraggableButton(self.toolbar, text="Button")
        self.text = tk.Entry(self.toolbar)
        self.check = tk.Checkbutton(self.toolbar, text="Check")
        self.radio = tk.Radiobutton(self.toolbar, text="Radio")
        self.combo = tk.OptionMenu(self.toolbar, tk.StringVar(), "Option 1", "Option 2", "Option 3")

        # Pack the buttons and other GUI objects into the toolbar
        self.button.pack(side=tk.LEFT, padx=2, pady=2)
        self.text.pack(side=tk.LEFT, padx=2, pady=2)
        self.check.pack(side=tk.LEFT, padx=2, pady=2)
        self.radio.pack(side=tk.LEFT, padx=2, pady=2)
        self.combo.pack(side=tk.LEFT, padx=2, pady=2)
        self.toolbar.pack(side=tk.TOP, fill=tk.X)

        # Create the canvas
        self.canvas = tk.Canvas(self.root, width=500, height=500, bg="white")
        self.canvas.pack(fill=tk.BOTH, expand=True)

        # Bind events to allow dragging and dropping GUI objects onto the canvas
        self.canvas.bind("<ButtonPress-1>", self.on_button_press)
        self.canvas.bind("<B1-Motion>", self.on_button_motion)
        self.canvas.bind("<ButtonRelease-1>", self.on_button_press)

        self.current_object = None
        self.start_x = None
        self.start_y = None
        self.dragging = False

        self.root.mainloop()

    def on_button_press(self, event):
        # Check if a DraggableButton is being clicked
        if isinstance(event.widget, DraggableButton):
            self.current_object = event.widget
            self.start_x = event.x
            self.start_y = event.y
            self.dragging = True
        else:
            # Determine which GUI object to create based on the type of button that was clicked
            if event.widget == self.button:
                new_object = tk.Button(self.canvas, text="Button")
            elif event.widget == self.text:
                new_object = tk.Entry(self.canvas)
            elif event.widget == self.check:
                new_object = tk.Checkbutton(self.canvas, text="Check")
            elif event.widget == self.radio:
                new_object = tk.Radiobutton(self.canvas, text="Radio")
            elif event.widget == self.combo:
                new_object = tk.OptionMenu(self.canvas, tk.StringVar(), "Option 1", "Option 2", "Option 3")
            else:
                return

            # Place the new GUI object on the canvas at the location of the mouse click
            new_object.place(x=event.x, y=event.y)
            self.current_object = new_object
            self.start_x = event.x
            self.start_y = event.y
            self.dragging = True

    def on_button_motion(self, event):
        if self.dragging:
            x = self.current_object.winfo_x() - self.start_x + event.x
            y = self.current_object.winfo_y() - self.start_y + event.y
            self.current_object.place(x=x, y=y)


gui = GUI_Builder()
           
