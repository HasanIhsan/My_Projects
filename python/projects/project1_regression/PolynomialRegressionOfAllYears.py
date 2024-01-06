import os
import pandas as pd
import matplotlib.pyplot as plt
import numpy as np
from sklearn.metrics import r2_score

# data located
data_folder = 'clean_data_files'

# current dir
current_directory = os.getcwd()

# Construct the full file paths for the CSV files within the folder
csv_files = [os.path.join(current_directory, data_folder, f'{year}_clean_data.csv') for year in range(2007, 2022)]

# Create a list to store R-squared values for each year
r_squared_values = []

# Create a function to perform polynomial regression and plot the results for each year
def perform_and_plot_polynomial_regression(year, x, y):
    # Fit a polynomial model
    model = np.poly1d(np.polyfit(x, y, 3))
    
    # Generate a range of x values for the regression line
    x_range = np.linspace(min(x), max(x), 100)
    
    # Calculate the corresponding y values using the polynomial model
    y_pred = model(x_range)
    
    # Calculate R-squared
    r_squared = r2_score(y, model(x))
    r_squared_values.append(r_squared)
    
    # Plot the polynomial regression line
    plt.plot(x_range, y_pred, label=f'Polynomial-{year}')
    
    # Display R-squared on the plot
    plt.text(max(x) - 3, max(y) - 5, f'R2 = {r_squared:.2f}', fontsize=10)


fig, ax = plt.subplots(figsize=(12, 6))

# Loop through each year, perform polynomial regression, and plot the results
for year, csv_file in zip(range(2007, 2022), csv_files):
    data = pd.read_csv(csv_file)
    x = data['BioDiesel']
    y = data['Total']
    perform_and_plot_polynomial_regression(year, x, y)

ax.set_title('Polynomial Regression for Each Years (2007-2021)')
ax.set_xlabel('BioDiesel')
ax.set_ylabel('Total')

# Move the legend 
ax.legend(loc='center left', bbox_to_anchor=(1, 0.6), prop={'size': 7})

plt.show()

# Print or use the R-squared values as needed
# Shown after chart is closed by user
for year, r_squared in zip(range(2007, 2022), r_squared_values):
    print(f"Year {year} - R2: {r_squared:.2f}")
