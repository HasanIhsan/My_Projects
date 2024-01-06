import os
import pandas as pd
from scipy import stats
import matplotlib.pyplot as plt
from sklearn.model_selection import cross_val_score
from sklearn.linear_model import LinearRegression
# where the CSV files are located  
data_folder = 'clean_data_files'

# Get the current working directory where your script is located
current_directory = os.getcwd()

# Construct the full file paths for the CSV files within the folder
csv_files = [os.path.join(current_directory, data_folder, f'{year}_clean_data.csv') for year in range(2007, 2022)]

# Create lists to store results for each year
slopes = []
intercepts = []
rsquared_values = []

# Create a function to perform linear regression and plot the results for each year
def perform_and_plot_linear_regression(year, x, y):
    slope, intercept, r, p, std_err = stats.linregress(x, y)
    slopes.append(slope)
    intercepts.append(intercept)
    rsquared_values.append(r)
    
    mymodel = [slope * xi + intercept for xi in x]

    plt.scatter(x, y, label=f'R Line - {year}')
    plt.plot(x, mymodel)

# change chart size
fig, ax = plt.subplots(figsize=(12, 6))

# Loop through each year, perform linear regression, and plot the results
for year, csv_file in zip(range(2007, 2022), csv_files):
    data = pd.read_csv(csv_file)
    x = data['BioDiesel']
    y = data['Total']
    perform_and_plot_linear_regression(year, x, y)

ax.set_title('Linear Regression for Each Year (2007-2021)')
ax.set_xlabel('BioDiesel')
ax.set_ylabel('Total')

# Move the legend to the right and make it smaller
ax.legend(loc='center left', bbox_to_anchor=(1, 0.6), prop={'size': 7})

plt.show()

# Print or use the results as needed
for year, slope, intercept, r in zip(range(2007, 2022), slopes, intercepts, rsquared_values):
    print(f"Year {year} - Slope: {slope}, Intercept: {intercept}, R-squared: {r}")

# Prepare your data for cross-validation
X = [data['BioDiesel'] for data in (pd.read_csv(csv_file) for csv_file in csv_files)]
y = [data['Total'] for data in (pd.read_csv(csv_file) for csv_file in csv_files)]

# Create a linear regression model
model = LinearRegression()

# Perform 5-fold cross-validation, measuring R-squared
cross_val_scores = cross_val_score(model, X, y, cv=5, scoring='r2')

# Print the R-squared scores for each fold
print("Cross-validation R-squared scores:", cross_val_scores)

# Calculate the mean R-squared score
mean_r2 = cross_val_scores.mean()
print("Mean Cross-validation R-squared score:", mean_r2)