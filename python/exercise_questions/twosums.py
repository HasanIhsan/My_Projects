#given an array of ints, return indices of the two numbers such that they add up to the target
# ex arr = [2, 7, 11, 13] target = 9
#output: (0, 1)

def return_to_sums(arr, traget):
    indicies = {} #create dictionary 
    
    for i, num in enumerate(arr):
        print(f"i  = {i}", f"num = {num}")
        
        com = target - num #calculate the complement of the current number
         
        
        if com in indicies:
            #if found return the index
            return indicies[com], i
        #otherwise store the index 
        indicies[num] = i
     
    


if __name__ == "__main__":
    #arr = [2, 7, 11, 13] #should return 0, 1
    #arr = [2, 11, 7, 13] #should return 0, 2
    arr = [3, 2, 11, 7] #should return 1, 3
    target = 9
    nums = return_to_sums(arr, target)
    print(nums)
    