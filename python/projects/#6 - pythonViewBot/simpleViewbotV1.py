import time
from selenium import webdriver

def add_views(url, num_views): 
    # set up the chrome webdriver
    driver = webdriver.Edge()
    
    try:
        #navigate to tge video URL
        driver.get(url)
        
        #simulate view by refreshing
        for _ in range(num_views):
            driver.refresh()
            time.sleep(5) # pause for 5 seconds
            
        print(f"{num_views} views added")
        
    except Exception as e:
        print(f"Error: {e}")
        
    finally:
        #close the driver
        driver.quit()
        
        
if __name__ == "__main__":
    url = input("Enter the video URL: " )
    num_views = input("Enter the number of views: ")
    add_views(url, num_views)