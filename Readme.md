# Getting Started

> Disclaimer: I'm still learning the possibilities of [Dolt](https://github.com/dolthub/dolt)!

Execute the following steps

* Clone this repo
* Run `docker-compose build`
* Run `docker-compose up -d`
* Run `docker exec -it dolt_tippspiel_db_1 bash -l`
* Run from the docker instance
  * `dolt remote add origin toburger/test`
  * `dolt pull`
  * You can exit the docker instance

Now everything should be ready to perform your first SQL queries...

There exists a F# `Script.fsx` files with some example queries...

