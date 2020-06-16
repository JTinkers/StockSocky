<template>
	<v-dialog width='400' v-model='show'>
		<v-card>
			<v-card-title>
				<span class='headline' v-text='"Stock"'/>
			</v-card-title>
			<v-form ref='form'>
				<v-container>
					<v-row>
						<v-col cols='6'>
							<v-text-field outlined label='Name' v-model='item.name'/>
						</v-col>
						<v-col cols='6'>
							<v-text-field outlined label='Symbol' v-model='item.symbol'/>
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
					await this.$axios.put('/api/stocks/' + this.item.id, this.item)
				else
					await this.$axios.post('/api/stocks', this.item)

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
