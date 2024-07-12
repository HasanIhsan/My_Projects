#give a  m x n integer gird where account [i][j] return the wealth of the richest person
#input = [[7,1,3],[2,8,7],[1,9,5]]
#output = 17

#basically add all the nums and return the largest sum


#note: this was acually done by me!
#i needed help on adding the sums in the array so google helped
def richcustomer(arr):
    total = 0
    min = 0
    max = 0
    #print(len(arr)) # length = 3
    #print(arr[0])# 0 = 7, 1, 3
    arr2 = []
    for i in range(len(arr)):
        arr2 = arr[i]
        
        for i in range(len(arr2)):
            total = sum(arr2)
            min = total
             
        if max < min:
            max = min     
         
        #print(arr2)
        #print(arr[i])
    
    return max



if __name__ == "__main__":
    arr = [[7, 1, 3], [2, 8, 7], [1, 9, 5]]
    
    print(arr)
    print(richcustomer(arr))
    
    