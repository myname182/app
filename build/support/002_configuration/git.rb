configs ={
  :git => {
    :user => missing("user",__FILE__),
    :remotes => potentially_change("remotes",__FILE__),
    :repo => 'app' 
  }
}
configatron.configure_from_hash(configs)
