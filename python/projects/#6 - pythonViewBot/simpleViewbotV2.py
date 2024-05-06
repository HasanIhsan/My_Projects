import time
import argparse
from selenium import webdriver

def add_views(url, num_views): 
    # set up the Edge webdriver
    driver = webdriver.Edge()
    
    try:
        # navigate to the video URLS
        driver.get(url)
        
        # simulate view by refreshing
        for _ in range(int(num_views)):
            driver.refresh()
            #time.sleep(5) # pause for 5 seconds ()
            time.sleep(20 * 60)  # pause for 20 minutes
            
        print(f"{num_views} views added")
        
    except Exception as e:
        print(f"\tError: {e}")
        
    finally:
        # close the driver
        driver.quit()
        
        
if __name__ == "__main__":
    print("Simple Youtube Viewbot")
    parser = argparse.ArgumentParser(description='Simple YouTube view bot')
    parser.add_argument('url', type=str, help='Video URL')
    parser.add_argument('num_views', type=int, help='Number of views')
    args = parser.parse_args()
    
    add_views(args.url, args.num_views)
