#Use two loops: The outer loop picks all the elements of arr2[] one by one. The inner loop linearly 
# searches for the element picked by the outer loop. If all elements are found then return 1, else return 0.

#python program to find wheather an array 
# is subset of antoher array


#return 1 if arr2[] is a subset or arr1[]

def isSubset(arr1, arr2, m, n):
    i = 0
    j = 0
    for i in range(n):
        for j in range(m):
            if(arr2[i] == arr1[i]):
                break
        
        #if the abover inner loop was
        # not broken at all then arr2[i]
        #is not preasent in arr1[]
        if(j == m):
            return 0
    
    #if we reach here then all
    #element of arr2[] are present 
    #in arr1[]
    return 1


if __name__ == "__main__":
    arr1 = [11, 1, 13, 21, 3, 7]
    arr2 = [11, 3, 7, 2]
    
    m = len(arr1)
    n = len(arr2)
    
    
    print("checking if array 1 is a subset of array 2")
    #Naive Approach to Find whether an array is subset of another array
    print("\nNaive Approach to Find whether an array is subset of another array") 
    print("\nUse two loops: The outer loop picks all the elements of arr2[] one by one. The inner loop linearly searches for the element picked by the outer loop. If all elements are found then return 1, else return 0.\n\n")
    if(isSubset(arr1, arr2, m, n)):
        print("arr2[] is subset of arr1 ")
    else:
        print("arr2[] is not a subset of arr1[]")
        
        
        