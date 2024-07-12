#running  sum of 1d Array
#Ex:
#   [3, 1, 2, 10, 1]
# output: [3, 4, 6, 16 ,17]

# takes the perivos numbers and adds them 

#note: this was mainly help of google, i didn't really do this
def runningsums(arr ):
    arr2 = [0] * len(arr)
    
    arr2[0] = arr[0]
    for i, num in enumerate(arr):
        print(f"i = {i}")
        print(f"nums = {num}")
        
       # newnum = arr[0] 
        if i == 0:
            arr2[0] = num
        else:
            arr2[i] = arr2[i- 1] + num
         
        
   
    
   # for i in range(1, len(arr)):
    #    arr2[i] = arr2[i - 1] + arr[i]  
         
        
    return arr2




if __name__ == "__main__":
    print("running sums")
    nums = [3, 1, 2, 10, 1]
    print(runningsums(nums))