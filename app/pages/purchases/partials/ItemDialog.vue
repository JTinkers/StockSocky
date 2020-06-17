<template>
	<v-dialog width='400' v-model='show'>
		<v-card>
			<v-card-title>
				<span class='headline' v-text='"Stock"'/>
			</v-card-title>
			<v-form ref='form'>
				<v-container>
					<v-row>
						<v-col cols='12'>
							<v-select outlined :disabled='item.id != null' :items='stocks' item-value='id' :item-text='(item) => item.symbol + " - " + item.name' label='Stock' v-model='item.stockId'/>
						</v-col>
					</v-row>
					<v-row>
						<v-col cols='6'>
							<v-text-field outlined label='Quantity' type='number' v-model='item.quantity'/>
						</v-col>
						<v-col cols='6'>
							<v-text-field outlined label='Value (per piece)' type='number' v-model='item.value'/>
						</v-col>
					</v-row>
				</v-container>
			</v-form>
			<v-card-actions>
				<v-container>
					<v-row justify='end'>
						<v-btn text v-text='"Save"' @click='save'/>
						<v-btn text v-text='"Cancel"' @click='cancel'/>
					</v-row>
				</v-container>
			</v-card-actions>
		</v-card>
	</v-dialog>
</template>

<script>
	export default
	{
		data: () =>
		({
			show: false,
			item: {}
		}),
		computed:
		{
			stocks()
			{
				return this.$store.state.stocks.items
			}
		},
		methods:
		{
			open(values)
			{
				this.$set(this, 'item', values || {})

				this.show = true
			},
			async save()
			{
				// update else add
				if(this.item.id)
					this.$store.dispatch('purchases/update', this.item)
				else
					this.$store.dispatch('purchases/create', this.item)

				this.cancel()
			},
			cancel()
			{
				this.$set(this, 'item', {})

				this.show = false
			}
		}
	}
</script>
