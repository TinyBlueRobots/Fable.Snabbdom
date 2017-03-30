module App

open Elmish
open Elmish.Snabbdom
open Fable.Helpers.Snabbdom
open Fable.Helpers.Snabbdom.Props

open Fable.Core
open Fable.Import
open Fable.Import.Snabbdom

type Msg =
  | Increment
  | Decrement

let init () = 0

let update msg count =
  match msg with
  | Increment -> count + 1
  | Decrement -> count - 1

let view count dispatch =
  let onClick msg =
    fun _ -> dispatch msg
    |> OnClick

  div []
    [ button
        [ events [ onClick Decrement ] ]
        [ unbox "-" ]
      div
        [ ]
        [ unbox (string count) ]
      button
        [ events [ onClick Increment ] ]
        [ unbox "+" ]
    ]

Program.mkSimple init update view
|> Program.withConsoleTrace
|> Program.withSnabbdom "elmish-app"
|> Program.run