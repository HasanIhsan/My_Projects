#Find weather an array is subset of another array using sorting and binary search
#The idea is to sort the given array arr1[], and then for each element in arr2[] do a binary search for it in sorted arr1[]. 
# If the element is not found then return 0. If all elements are present then return 1.

#Algorithm:

#he algorithm is pretty straightforward. 

#Sort the first array arr1[].
#Look for the elements of arr2[] in sorted arr1[].
#If we encounter a particular value that is present in arr2[] but not in arr1[], the code will terminate, arr2[] can never be the subset of arr1[].
#Else arr2[] is the subset of arr1[].
#Below is the code implementation of the above approach :

 


#uses quick sort
#and binary search
def isSubset(arr1, arr2, m, n):
    i = 0
    
    quickSort(arr1, 0, m-1)
    for i in range(n):
        if(binarySearch(arr1, 0, m - 1, arr2[i]) == -1):
            return 0
        
    #if we reach here then all elements a
    #of arr2[] are present in arr1[]
    return 1


#FOLLOWING FUNCTIONS ARE ONLY FOR SEARCH AND SOTRING PURPOSES


#Standard binary search function

def binarySearch(arr, low, high, x):
    if(high >= low):
        mid = (low + high) // 2
        
        #check if arr[mid] is the first
        # occurrence of x
        # arr[mid] is first occurence if x is
        # one of the following
        #is true:
        # (i) mid == 0 and arr[mid] == x
        # (ii) arr[mid - 1] < x and arr[mid] == x
        
        if((mid == 0 or x > arr[mid - 1]) and (arr[mid] == x )):
            return mid
        elif(x > arr[mid]):
            return binarySearch(arr, (mid + 1), high, x)
        else:
            return binarySearch(arr, low, (mid - 1), x)
        
    return -1


def partition(A, si, ei):
    x = A[ei]
    i = (si - 1)
    
    for j in range(si, ei):
        if(A[j] <= x):
            i += 1
            A[i], A[j] = A[j], A[i]
    A[ i + 1], A[ei] = A[ei], A[i + 1]
    return (i + 1)

# Implementation of Quick Sort
# A[] --> Array to be sorted
# si --> Starting index
# ei --> Ending index


def quickSort(A, si, ei):
    #partitioning index
    if(si < ei):
        pi = partition(A, si, ei)
        quickSort(A, si, pi - 1)
        quickSort(A, pi + 1, ei)
        
        

arr1 = [11, 1, 13, 21, 3, 7]
arr2 = [11, 3, 7, 1]

m = len(arr1)
n = len (arr2)


print("Find whether an array is subset of another array using Sorting and Binary Search")

print("\nThe idea is to sort the given array arr1[], and then for each element in arr2[] do a binary search for it in sorted arr1[]. If the element is not found then return 0. If all elements are present then return 1.")

print("\n\nGiven array arr1[] = { 11, 1, 13, 21, 3, 7 } and arr2[] = { 11, 3, 7, 1 }.")
print("Step 1: We will sort the array arr1[], and have arr1[] = { 1, 3, 7, 11, 13, 21}.")
print("Step 2: We will look for each element in arr2[] in arr1[] using binary search.")
print("\t\narr2[] = { 11, 3, 7, 1 }, 11 is present in arr1[] = { 1, 3, 7, 11, 13, 21}")
print("\tarr2[] = { 11, 3, 7, 1 }, 3 is present in arr1[] = { 1, 3, 7, 11, 13, 21}")
print("\tarr2[] = { 11, 3, 7, 1 }, 7 is present in arr1[] = { 1, 3, 7, 11, 13, 21}")
print("\tarr2[] = { 11, 3, 7, 1 }, 1 is present in arr1[] = { 1, 3, 7, 11, 13, 21}")
print("\n\nAs all the elements are found we can conclude arr2[] is the subset of arr1[].\n\n")


print("\nAlgorithm:")

print("\n\nThe algorithm is pretty straightforward. ")
 
print("\tSort the first array arr1[].")
print("\tLook for the elements of arr2[] in sorted arr1[].")
print("\tIf we encounter a particular value that is present in arr2[] but not in arr1[], the code will")
print("\tterminate, arr2[] can never be the subset of arr1[].")
print("\tElse arr2[] is the subset of arr1[].")

print("\n\n")

if(isSubset(arr1, arr2, m, n)):
    print("arr2 is subset of arr1")
else:
    print("not subseet")
    
    