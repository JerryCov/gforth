\ Starting forth
: star 42 emit ;
: margin cr 30 spaces ;
: blip margin star ;
: stars 0 do star loop ;
: bar margin 5 stars ;
: blip margin star ;
: F bar blip bar blip blip ;
: gap margin star 3 spaces star ;
: O bar gap gap gap bar ;

cr F cr O cr 
