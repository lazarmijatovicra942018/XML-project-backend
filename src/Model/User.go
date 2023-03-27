package Model

import (
	"go.mongodb.org/mongo-driver/bson/primitive"
)

type Role string

type User struct {
	ID      primitive.ObjectID `bson:"_id,omitempty" json:"id"`
	Name    string             `bson:"name" json:"name"`
	Surname string             `bson:"surname,omitempty" json:"surname"`
	Type    string             `bson:"role" json:"role" validate:"required"`
}
