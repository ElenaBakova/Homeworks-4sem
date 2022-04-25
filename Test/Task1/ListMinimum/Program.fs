module ListMinimum

/// Finds minimum in the list
let findMin list =
    List.sort list |> List.head
