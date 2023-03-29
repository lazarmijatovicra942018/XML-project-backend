package model

import (
	"time"

	"go.mongodb.org/mongo-driver/bson/primitive"
)

type User struct {


	ID            primitive.ObjectID   `bson:"_id" json:"_id"`
	First_Name    *string              `bson:"first_name" json:"first_name" validate:"required,min=2,max=30"`
	Last_Name     *string              `bson:"last_name" json:"last_name"  validate:"required,min=2,max=30"`
	Password      *string              `bson:"password" json:"password"   validate:"required,min=6"`
	Email         *string              `bson:"email" json:"email"      validate:"email,required"`
	Token         *string              `bson:"token" json:"token"`
	Refresh_Token *string              `bson:"refresh_token" json:"refresh_token"`
	Type        *Type                `bson:"role" json:"role" validate:"required"`
	User_ID       string               `bson:"user_id" json:"user_id"`
	Created_At    time.Time            `bson:"created_at" json:"created_at"`
	Updated_At    time.Time            `bson:"updated_at" json:"updated_at"`
	UserTickets   []primitive.ObjectID `bson:"user_tickets" json:"user_tickets"`
}
